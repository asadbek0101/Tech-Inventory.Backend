using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.CounterFeature.CreateCounter;
using Tech_Inventory.Application.Features.CounterFeature.DeleteCounter;
using Tech_Inventory.Application.Features.CounterFeature.GetAllCounters;
using Tech_Inventory.Application.Features.CounterFeature.GetOneCounter;
using Tech_Inventory.Application.Features.CounterFeature.UpdateCounter;

namespace Tech_Inventory.WebApi.Controllers;

public class CountersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllCountersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneCounterRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateCounterRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateCounterRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteCounterRequest request)
    {
        return await Mediator.Send(request);
    }
}
