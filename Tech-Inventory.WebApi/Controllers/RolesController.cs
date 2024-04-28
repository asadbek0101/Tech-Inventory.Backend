using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.RegionFeature.GetRegionsList;
using Tech_Inventory.Application.Features.RoleFeature.GetRolesList;

namespace Tech_Inventory.WebApi.Controllers;

public class RolesController : BaseController
{
    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList()
    {
        return await Mediator.Send(new GetRolesListRequest()); 
    }
}
