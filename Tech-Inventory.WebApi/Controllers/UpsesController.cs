using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.UpsFeature.CreateUps;
using Tech_Inventory.Application.Features.UpsFeature.DeleteUps;
using Tech_Inventory.Application.Features.UpsFeature.GetAllUpses;
using Tech_Inventory.Application.Features.UpsFeature.GetOneUps;
using Tech_Inventory.Application.Features.UpsFeature.UpdateUps;

namespace Tech_Inventory.WebApi.Controllers;

public class UpsesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllUpsesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneUpsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateUpsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateUpsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteUpsRequest request)
    {
        return await Mediator.Send(request);
    }
}
