using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.VideoRecorderFeature.CreateVideoRecorder;
using Tech_Inventory.Application.Features.VideoRecorderFeature.DeleteVideoRecorder;
using Tech_Inventory.Application.Features.VideoRecorderFeature.GetAllVideoRecorders;
using Tech_Inventory.Application.Features.VideoRecorderFeature.GetOneVideoRecorder;
using Tech_Inventory.Application.Features.VideoRecorderFeature.UpdateVideoRecorder;

namespace Tech_Inventory.WebApi.Controllers;

public class VideoRecordersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllVideoRecordersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneVideoRecorderRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateVideoRecorderRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateVideoRecorderRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteVideoRecorderRequest request)
    {
        return await Mediator.Send(request);
    }
}
