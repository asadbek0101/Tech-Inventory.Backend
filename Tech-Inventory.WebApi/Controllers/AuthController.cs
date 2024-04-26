using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Auth.LoginUser;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.WebApi.Controllers;

public class AuthController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginUserRequest request)
    {
        return await Mediator.Send(request);
    }
}
