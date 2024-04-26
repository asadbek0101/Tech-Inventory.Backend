using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.UserFeature.CreateUser;
using Tech_Inventory.Application.Features.UserFeature.DeleteUser;
using Tech_Inventory.Application.Features.UserFeature.GetAllusers;
using Tech_Inventory.Application.Features.UserFeature.GetOneUser;
using Tech_Inventory.Application.Features.UserFeature.UpdateUser;

namespace Tech_Inventory.WebApi.Controllers;

public class UsersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllUsersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateUserRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteUserRequest request)
    {
        return await Mediator.Send(request);
    }
}
