using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.StreetFeature.GetStreetsList;

namespace Tech_Inventory.WebApi.Controllers;

public class StreetController : BaseController
{
    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList([FromQuery] GetStreetsListRequest request)
    {
        return await Mediator.Send(request);
    }
}
