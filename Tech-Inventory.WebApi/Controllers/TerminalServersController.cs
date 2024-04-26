using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.TerminalServerFeature.CreateTerminalServer;
using Tech_Inventory.Application.Features.TerminalServerFeature.GetAllTerminalServers;

namespace Tech_Inventory.WebApi.Controllers;

public class TerminalServersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllTerminalServersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateTerminalServerRequest request)
    {
        return await Mediator.Send(request);
    }
}
