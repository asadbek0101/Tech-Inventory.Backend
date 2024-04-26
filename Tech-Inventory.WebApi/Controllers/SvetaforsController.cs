using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.SvetaforFeature.CreateSvetafor;
using Tech_Inventory.Application.Features.SvetaforFeature.DeleteSvetafor;
using Tech_Inventory.Application.Features.SvetaforFeature.GetAllSvetafors;
using Tech_Inventory.Application.Features.SvetaforFeature.GetOneSvetafor;
using Tech_Inventory.Application.Features.SvetaforFeature.UpdateSvetafor;

namespace Tech_Inventory.WebApi.Controllers;

public class SvetaforsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllSvetaforsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneSvetaforRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateSvetaforRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateSvetaforRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteSvetaforRequest request)
    {
        return await Mediator.Send(request);
    }
}
