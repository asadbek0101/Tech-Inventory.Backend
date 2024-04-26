using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.StanchionFeature.CreateStanchion;
using Tech_Inventory.Application.Features.StanchionFeature.GetAllStanchions;

namespace Tech_Inventory.WebApi.Controllers;

public class StanchionsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllStanchionsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateStanchionRequest request)
    {
        return await Mediator.Send(request);
    }
}
