using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.StabilizerFeature.CreateStabilizer;
using Tech_Inventory.Application.Features.StabilizerFeature.DeleteStabilizer;
using Tech_Inventory.Application.Features.StabilizerFeature.GetAllStabilizers;
using Tech_Inventory.Application.Features.StabilizerFeature.GetOneStabilizer;
using Tech_Inventory.Application.Features.StabilizerFeature.UpdateStabilizer;

namespace Tech_Inventory.WebApi.Controllers;

public class StabilizersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllStabilizersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneStabilizerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateStabilizerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateStabilizerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteStabilizerRequest request)
    {
        return await Mediator.Send(request);
    }
}
