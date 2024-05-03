using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Auth.ResetPassword;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IConfiguration _config;

    public ResetPasswordHandler(UserManager<ApplicationUser> userManager, IConfiguration config, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }
    public async Task<ApiResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var hasUser = await _userManager.FindByIdAsync(request.UserId.ToString());
            var response = new ResetPasswordResponse { Id = request.UserId };

            if(hasUser != null)
            {
                var isCorrect = await _userManager.CheckPasswordAsync(hasUser, request.OldPassword);
                if(isCorrect)
                {
                  var removeResult = await _userManager.RemovePasswordAsync(hasUser);
                  var addResult = await _userManager.AddPasswordAsync(hasUser, request.NewPassword);

                    if (addResult.Succeeded)
                    {
                        response.Message = "Password has changed";
                    }
                    else
                    {
                        var errorMessage = "";
                        foreach (var item in addResult.Errors)
                        {
                            errorMessage = errorMessage + item.Description + " ";
                        }

                        response.Message = errorMessage;
                    }
                }
                else
                {
                    response.Message = "Password has not changed";
                }
            }
            else
            {
                response.Message = "User not found";
            }

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}

