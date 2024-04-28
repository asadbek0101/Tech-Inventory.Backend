using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ModelFeature.CreateModel;
using Tech_Inventory.Application.Features.ModelFeature.DeleteModels;
using Tech_Inventory.Application.Features.ModelFeature.GetAllModels;
using Tech_Inventory.Application.Features.ModelFeature.GetModelsList;
using Tech_Inventory.Application.Features.ModelFeature.GetOneModel;
using Tech_Inventory.Application.Features.ModelFeature.UpdateModel;

namespace Tech_Inventory.WebApi.Controllers;

public class ModelsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllModelsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList([FromQuery] GetModelsListRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneModelRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateModelRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateModelRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Delete")]
    public async Task<ActionResult<ApiResponse>> DeleteByIds([FromBody] DeleteModelsRequest request)
    {
        return await Mediator.Send(request);
    }
}
