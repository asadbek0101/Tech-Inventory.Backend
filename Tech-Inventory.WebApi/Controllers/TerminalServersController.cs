using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.TerminalServerFeature.CreateTerminalServer;
using Tech_Inventory.Application.Features.TerminalServerFeature.DeleteTerminalServer;
using Tech_Inventory.Application.Features.TerminalServerFeature.GetAllTerminalServers;
using Tech_Inventory.Application.Features.TerminalServerFeature.GetOenTerminalServer;
using Tech_Inventory.Application.Features.TerminalServerFeature.UpdateTerminalServer;

namespace Tech_Inventory.WebApi.Controllers;

public class TerminalServersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllTerminalServersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneTerminalServerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateTerminalServerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateTerminalServerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteTerminalServerRequest request)
    {
        return await Mediator.Send(request);
    }
}
