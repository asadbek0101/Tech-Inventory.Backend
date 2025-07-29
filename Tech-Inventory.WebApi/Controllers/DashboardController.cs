using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.DashboardFeature.GetActiveUsersDashboard;
using Tech_Inventory.Application.Features.DashboardFeature.GetObjectsDashboard;

namespace Tech_Inventory.WebApi.Controllers;

public class DashboardController : BaseController
{
    [HttpGet("GetObjects")]
    public async Task<ActionResult<ApiResponse>> GetObjects([FromQuery] GetObjectsDashboardRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetUsers")]
    public async Task<ActionResult<ApiResponse>> GetUsers([FromQuery] GetUserDashboardRequest request)
    {
        return await Mediator.Send(request);
    }
}
