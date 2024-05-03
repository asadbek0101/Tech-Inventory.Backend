using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ServerFeature.CreateServer;
using Tech_Inventory.Application.Features.ServerFeature.DeleteServer;
using Tech_Inventory.Application.Features.ServerFeature.GetAllServers;
using Tech_Inventory.Application.Features.ServerFeature.GetOneServer;
using Tech_Inventory.Application.Features.ServerFeature.UpdateServer;

namespace Tech_Inventory.WebApi.Controllers;

public class ServersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllServersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneServerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateServerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateServerRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteServerRequest request)
    {
        return await Mediator.Send(request);
    }
}
