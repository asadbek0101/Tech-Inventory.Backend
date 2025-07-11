using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ObyektFeature.CreateObyekt;
using Tech_Inventory.Application.Features.ObyektFeature.DeleteObyekt;
using Tech_Inventory.Application.Features.ObyektFeature.DeleteObyekts;
using Tech_Inventory.Application.Features.ObyektFeature.GetAllObyekts;
using Tech_Inventory.Application.Features.ObyektFeature.GetObyektProducts;
using Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;
using Tech_Inventory.Application.Features.ObyektFeature.UpdateObyekt;
using Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

namespace Tech_Inventory.WebApi.Controllers;

public class ObyektsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllObyektsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetProductsCounts")]
    public async Task<ActionResult<ApiResponse>> GetPruducts([FromQuery] GetObyektProductsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneObyektRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetObyektReport")]
    public async Task<ActionResult<ObyektReportResponse>> Get([FromQuery] ObyektReportRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateObyektRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Delete")]
    public async Task<ActionResult<ApiResponse>> DeleteByIds([FromBody] DeleteObyektsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateObyektRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteObyektRequest request)
    {
        return await Mediator.Send(request);
    }
}
