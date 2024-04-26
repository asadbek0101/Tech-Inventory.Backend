using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.SwitchFeature.CreateSwitch;
using Tech_Inventory.Application.Features.SwitchFeature.DeleteSwitch;
using Tech_Inventory.Application.Features.SwitchFeature.GetAllSwitches;
using Tech_Inventory.Application.Features.SwitchFeature.GetOneSwitch;
using Tech_Inventory.Application.Features.SwitchFeature.UpdateSwitch;

namespace Tech_Inventory.WebApi.Controllers;

public class SwitchesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllSwitchesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneSwitchRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateSwitchRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateSwitchRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteSwitchRequest request)
    {
        return await Mediator.Send(request);
    }
}
