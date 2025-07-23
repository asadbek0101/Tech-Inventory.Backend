using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.DashboardFeature.GetDashboard;

namespace Tech_Inventory.WebApi.Controllers;

public class DashboardController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetDashboardRequest request)
    {
        return await Mediator.Send(request);
    }
}
