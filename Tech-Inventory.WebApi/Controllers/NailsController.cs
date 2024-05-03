using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.NailFeature.CreateNail;
using Tech_Inventory.Application.Features.NailFeature.DeleteNail;
using Tech_Inventory.Application.Features.NailFeature.GetAllNails;
using Tech_Inventory.Application.Features.NailFeature.GetOneNail;
using Tech_Inventory.Application.Features.NailFeature.UpdateNail;

namespace Tech_Inventory.WebApi.Controllers;

public class NailsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllNailsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneNailRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateNailRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateNailRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteNailRequest request)
    {
        return await Mediator.Send(request);
    }
}
