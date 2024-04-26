using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.AttechmentFeature.CreateAttechment;
using Tech_Inventory.Application.Features.AttechmentFeature.DeleteAttechment;
using Tech_Inventory.Application.Features.AttechmentFeature.GetAllAttechments;
using Tech_Inventory.Application.Features.AttechmentFeature.GetOneAttechment;
using Tech_Inventory.Application.Features.AttechmentFeature.UpdateAttechment;

namespace Tech_Inventory.WebApi.Controllers;

public class AttachmentsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllAttechmentsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneAttechmentRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateAttechmentRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateAttechmentRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteAttechmentRequest request)
    {
        return await Mediator.Send(request);
    }
}
