using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Common.Settings;

namespace Tech_Inventory.WebApi.Middleware;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _secretKey;

    public TokenValidationMiddleware(RequestDelegate next, IOptions<JwtSettings> options)
    {
        _next = next;
        _secretKey = options.Value.SecretKey;
    }

    public async Task Invoke(HttpContext context)
    {
        var tokenService = context.RequestServices.GetRequiredService<IUserTokenService>();

        var path = context.Request.Path.Value?.ToLower();

        var excludedPaths = new[]
        {
        "/api/auth/login",
    };

        if (excludedPaths.Any(p => path.StartsWith(p)))
        {
            await _next(context);
            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Token yo'q");
            return;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_secretKey);

        try
        {
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var userId = principal.FindFirst("UserId")?.Value;

            if (userId != null)
            {
                //var savedToken = await tokenService.GetSavedTokenAsync(Convert.ToInt32(userId));
                //if (savedToken != token)
                //{
                //    context.Response.StatusCode = 401;
                //    await context.Response.WriteAsync("Token is invalid or expired.");
                //    return;
                //}

                context.User = principal;
            }

            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Token yaroqsiz yoki muddati tugagan");
        }
    }
}