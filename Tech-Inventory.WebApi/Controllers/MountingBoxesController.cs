using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.MountingBoxFeature.CreateMountingBox;
using Tech_Inventory.Application.Features.MountingBoxFeature.DeleteMountingBox;
using Tech_Inventory.Application.Features.MountingBoxFeature.GetAllMountingBoxes;
using Tech_Inventory.Application.Features.MountingBoxFeature.GetOneMountingBox;
using Tech_Inventory.Application.Features.MountingBoxFeature.UpdateMountingBox;

namespace Tech_Inventory.WebApi.Controllers;

public class MountingBoxesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllMountingBoxesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneMountingBoxRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateMountingBoxRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateMountingBoxRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteMountingBoxRequest request)
    {
        return await Mediator.Send(request);
    }
}
