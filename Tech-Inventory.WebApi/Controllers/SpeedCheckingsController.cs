using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.SpeedCheckingFeature.CreateSpeedChecking;
using Tech_Inventory.Application.Features.SpeedCheckingFeature.GetAllSpeedCheckings;

namespace Tech_Inventory.WebApi.Controllers;

public class SpeedCheckingsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllSpeedCheckingsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateSpeedCheckingRequest request)
    {
        return await Mediator.Send(request);
    }
}
