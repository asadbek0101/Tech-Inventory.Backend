using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.CameraFeature.CreateCamera;
using Tech_Inventory.Application.Features.CameraFeature.DeleteCamera;
using Tech_Inventory.Application.Features.CameraFeature.GetAllCameras;
using Tech_Inventory.Application.Features.CameraFeature.GetOneCamera;
using Tech_Inventory.Application.Features.CameraFeature.UpdateCamera;

namespace Tech_Inventory.WebApi.Controllers;

public class CamerasController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllCamerasRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneCameraRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateCameraRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateCameraRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteCameraRequest request)
    {
        return await Mediator.Send(request);
    }
}
