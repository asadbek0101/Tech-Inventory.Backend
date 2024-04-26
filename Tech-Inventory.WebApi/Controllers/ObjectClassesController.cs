using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassFeature;

namespace Tech_Inventory.WebApi.Controllers;

public class ObjectClassesController : BaseController
{
    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> Get([FromQuery] GetObjectClassRequest request)
    {
        return await Mediator.Send(request);
    }
}
