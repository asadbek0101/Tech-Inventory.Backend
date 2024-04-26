using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.RackFeature.CreateRack;
using Tech_Inventory.Application.Features.RackFeature.DeleteRack;
using Tech_Inventory.Application.Features.RackFeature.GetAllRacks;
using Tech_Inventory.Application.Features.RackFeature.GetOneRack;
using Tech_Inventory.Application.Features.RackFeature.UpdateRack;

namespace Tech_Inventory.WebApi.Controllers;

public class RacksController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllRacksRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneRackRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateRackRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateRackRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteRackRequest request)
    {
        return await Mediator.Send(request);
    }
}
