using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ObjectClassTypeFeature.CreateObjectClassType;
using Tech_Inventory.Application.Features.ObjectClassTypeFeature.DeleteObjectClassTypes;
using Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetAllObjectClassTypes;
using Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetObejctClassTypesList;
using Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetOneObjectClassType;
using Tech_Inventory.Application.Features.ObjectClassTypeFeature.UpdateObjectClassType;

namespace Tech_Inventory.WebApi.Controllers;

public class ObjectClassTypesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllObjectClassTypesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList()
    {
        return await Mediator.Send(new GetObjectClassTypesListRequest());
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneObjectClassTypeRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateObjectClassTypeRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Delete")]
    public async Task<ActionResult<ApiResponse>> DeleteByIds([FromBody] DeleteObjectClassTypesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateObjectClassTypeRequest request)
    {
        return await Mediator.Send(request);
    }
}
