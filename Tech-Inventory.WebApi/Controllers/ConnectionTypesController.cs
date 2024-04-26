using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ConTypeFeature.CreateConType;

namespace Tech_Inventory.WebApi.Controllers;

public class ConnectionTypesController : BaseController
{
    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateConTypeRequest request)
    {
        return await Mediator.Send(request);
    }
}
