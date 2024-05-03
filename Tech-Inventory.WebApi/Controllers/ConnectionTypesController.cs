using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ConTypeFeature.CreateConType;
using Tech_Inventory.Application.Features.ConTypeFeature.UpdateConType;

namespace Tech_Inventory.WebApi.Controllers;

public class ConnectionTypesController : BaseController
{
    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateConTypeRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateConTypeRequest request)
    {
        return await Mediator.Send(request);
    }
}
