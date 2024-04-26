using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.AkumalatorFeature.CreateAkumalator;
using Tech_Inventory.Application.Features.AkumalatorFeature.DeleteAkumalator;
using Tech_Inventory.Application.Features.AkumalatorFeature.GetAllAkumalators;
using Tech_Inventory.Application.Features.AkumalatorFeature.GetOneAkumalator;
using Tech_Inventory.Application.Features.AkumalatorFeature.UpdateAkumalator;

namespace Tech_Inventory.WebApi.Controllers;

public class AkumalatorsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllAkumalatorsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneAkumalatorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateAkumalatorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateAkumalatorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteAkumalatorRequest request)
    {
        return await Mediator.Send(request);
    }
}
