using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.RibbonFeature.CreateRibbon;
using Tech_Inventory.Application.Features.RibbonFeature.DeleteRibbon;
using Tech_Inventory.Application.Features.RibbonFeature.GetAllRibbons;
using Tech_Inventory.Application.Features.RibbonFeature.GetOneRibbon;
using Tech_Inventory.Application.Features.RibbonFeature.UpdateRibbon;

namespace Tech_Inventory.WebApi.Controllers;

public class RibbonsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllRibbonsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneRibbonRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateRibbonRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateRibbonRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteRibbonRequest request)
    {
        return await Mediator.Send(request);
    }
}
