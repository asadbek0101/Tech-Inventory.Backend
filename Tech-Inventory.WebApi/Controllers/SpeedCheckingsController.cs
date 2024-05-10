using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.SpeedCheckingFeature.CreateSpeedChecking;
using Tech_Inventory.Application.Features.SpeedCheckingFeature.DeleteSpeedChecking;
using Tech_Inventory.Application.Features.SpeedCheckingFeature.GetAllSpeedCheckings;
using Tech_Inventory.Application.Features.SpeedCheckingFeature.GetOneSpeedChecking;
using Tech_Inventory.Application.Features.SpeedCheckingFeature.UpdateSpeedChecking;

namespace Tech_Inventory.WebApi.Controllers;

public class SpeedCheckingsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllSpeedCheckingsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneSpeedCheckingRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateSpeedCheckingRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateSpeedCheckingRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteSpeedCheckingRequest request)
    {
        return await Mediator.Send(request);
    }
}
