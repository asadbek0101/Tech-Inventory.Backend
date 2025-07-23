using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.DistrictFeature.GetDistrictsList;

namespace Tech_Inventory.WebApi.Controllers;

public class DistrictsController : BaseController
{
    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList([FromQuery] GetDistrictsListRequest request)
    {
        return await Mediator.Send(request);
    }
}
