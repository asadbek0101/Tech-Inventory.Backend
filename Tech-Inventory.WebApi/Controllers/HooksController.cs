using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.HookFeature.CreateHook;
using Tech_Inventory.Application.Features.HookFeature.DeleteHook;
using Tech_Inventory.Application.Features.HookFeature.GetAllHooks;
using Tech_Inventory.Application.Features.HookFeature.GetOneHook;
using Tech_Inventory.Application.Features.HookFeature.UpdateHook;

namespace Tech_Inventory.WebApi.Controllers;

public class HooksController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllHooksRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneHookRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateHookRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateHookRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteHookRequest request)
    {
        return await Mediator.Send(request);
    }
}
