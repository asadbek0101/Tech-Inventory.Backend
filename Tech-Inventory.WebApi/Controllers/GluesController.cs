using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.GlueFornailFeature.CreateGlue;
using Tech_Inventory.Application.Features.GlueFornailFeature.DeleteGlue;
using Tech_Inventory.Application.Features.GlueFornailFeature.GetAllGlues;

namespace Tech_Inventory.WebApi.Controllers;

public class GluesController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllGluesRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateGlueRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteGlueRequest request)
    {
        return await Mediator.Send(request);
    }
}
