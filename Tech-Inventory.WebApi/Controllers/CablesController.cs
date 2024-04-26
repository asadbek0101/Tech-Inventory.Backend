using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.CableFeature.CreateCabel;
using Tech_Inventory.Application.Features.CableFeature.DeleteCabel;
using Tech_Inventory.Application.Features.CableFeature.GetAllCabels;
using Tech_Inventory.Application.Features.CableFeature.GetOneCabel;
using Tech_Inventory.Application.Features.CableFeature.UpdateCabel;

namespace Tech_Inventory.WebApi.Controllers;

public class CablesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllCabelsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneCabelRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateCabelRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateCabelRequest request)
    {
        return await Mediator.Send(request);
    }
    
    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteCabelRequest request)
    {
        return await Mediator.Send(request);
    }
}
