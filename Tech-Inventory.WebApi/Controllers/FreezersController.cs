using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.FreezerFeature.CreateFreezer;
using Tech_Inventory.Application.Features.FreezerFeature.DeleteFreezer;
using Tech_Inventory.Application.Features.FreezerFeature.GetAllFreezers;
using Tech_Inventory.Application.Features.FreezerFeature.GetOneFreezer;
using Tech_Inventory.Application.Features.FreezerFeature.UpdateFreezer;

namespace Tech_Inventory.WebApi.Controllers;

public class FreezersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllFreezersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneFreezerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateFreezerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateFreezerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteFreezerRequest request)
    {
        return await Mediator.Send(request);
    }
}
