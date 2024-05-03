using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.BoxFeature.CreateBox;
using Tech_Inventory.Application.Features.BoxFeature.DeleteBox;
using Tech_Inventory.Application.Features.BoxFeature.GetAllBoxes;
using Tech_Inventory.Application.Features.BoxFeature.GetOneBox;
using Tech_Inventory.Application.Features.BoxFeature.UpdateBox;

namespace Tech_Inventory.WebApi.Controllers;

public class BoxesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllBoxesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneBoxRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateBoxRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateBoxRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteBoxRequest request)
    {
        return await Mediator.Send(request);
    }
}
