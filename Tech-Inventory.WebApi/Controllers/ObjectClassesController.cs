using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ObjectClassFeature.CreateObjectClass;
using Tech_Inventory.Application.Features.ObjectClassFeature.DeleteObjectClasses;
using Tech_Inventory.Application.Features.ObjectClassFeature.GetAllObjectClasses;
using Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassesList;
using Tech_Inventory.Application.Features.ObjectClassFeature.GetOneObjectClass;
using Tech_Inventory.Application.Features.ObjectClassFeature.UpdateObjectClass;

namespace Tech_Inventory.WebApi.Controllers;

public class ObjectClassesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllObjectClassesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList([FromQuery] GetObjectClassesListRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneObjectClassRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateObjectClassRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Delete")]
    public async Task<ActionResult<ApiResponse>> DeleteByIds([FromBody] DeleteObjectClassesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateObjectClassRequest request)
    {
        return await Mediator.Send(request);
    }
}
