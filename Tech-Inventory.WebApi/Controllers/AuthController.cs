using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Auth.LoginUser;
using Tech_Inventory.Application.Auth.ResetPassword;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.WebApi.Controllers;

public class AuthController : BaseController
{
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("ResetPassword")]
    public async Task<ActionResult<ApiResponse>> Reset([FromBody] ResetPasswordRequest request)
    {
        return await Mediator.Send(request);
    }
}
