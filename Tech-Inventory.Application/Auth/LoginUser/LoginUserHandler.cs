using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Auth.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IUserTokenRepository _userTokenService;
    private readonly IConfiguration _config;

    public LoginUserHandler(UserManager<ApplicationUser> userManager, IConfiguration config, RoleManager<ApplicationRole> roleManager,  IUserTokenRepository userTokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _userTokenService = userTokenService;
        _config = config;
    }

    public async Task<ApiResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var hasUser = await _userManager.FindByNameAsync(request.Username);

            var type = ResponseType.Success;

            if (hasUser != null)
            {
                var isCorrect = await _userManager.CheckPasswordAsync(hasUser, request.Password);

                if (!isCorrect)
                {
                    var response = new LoginUserResponse { Message = "Username or password invalid" };

                    return ResponseHandler.GetAppResponse(ResponseType.Success, response);
                }
                else
                {
                    type = ResponseType.Failed;
                    var token = await GenerateToken(hasUser);
                    await _userTokenService.SaveAsync(hasUser.Id, token, cancellationToken);
                    var response = new LoginUserResponse { UserId = hasUser.Id, Message = "Successfully logged", Token = token };
                    return ResponseHandler.GetAppResponse(type, response);
                }
            }
            else
            {
                type = ResponseType.Success;
                var reposne = new LoginUserResponse { Message = "Username or password invalid" };
                return ResponseHandler.GetAppResponse(type, reposne);
            }
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }

    private async Task<string> GenerateToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var userRoles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>()
        {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("RoleName", user.RoleName),
                new Claim("UserId", user.Id.ToString()),
        };

        foreach (var userRole in userRoles)
        {
            var role = await _roleManager.FindByNameAsync(userRole);
            if (role != null)
            {
                claims.Add(new Claim("role", userRole));
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var roleClaim in roleClaims)
                {
                    claims.Add(roleClaim);
                }
            }
        }

        var token = new JwtSecurityToken(
              _config["JwtSettings:Issuer"],
              _config["JwtSettings:Audience"],
              claims,
              expires: DateTime.UtcNow.AddMinutes(30),
              signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


