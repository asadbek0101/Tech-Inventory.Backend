using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.RegionFeature.GetRegionsList;

namespace Tech_Inventory.WebApi.Controllers;

[Authorize]
public class RegionsController : BaseController
{
    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList()
    {
        return await Mediator.Send(new GetRegionsListRequest());
    }
}
