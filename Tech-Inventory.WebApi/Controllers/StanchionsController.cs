using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.StanchionFeature.CreateStanchion;
using Tech_Inventory.Application.Features.StanchionFeature.DeleteStanchion;
using Tech_Inventory.Application.Features.StanchionFeature.GetAllStanchions;
using Tech_Inventory.Application.Features.StanchionFeature.GetOneStanchion;
using Tech_Inventory.Application.Features.StanchionFeature.UpdateStanchion;

namespace Tech_Inventory.WebApi.Controllers;

public class StanchionsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllStanchionsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneStanchionRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateStanchionRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateStanchionRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteStanchionRequest request)
    {
        return await Mediator.Send(request);
    }
}
