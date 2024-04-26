using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.SocketFeature.CreateSocket;
using Tech_Inventory.Application.Features.SocketFeature.DeleteSocket;
using Tech_Inventory.Application.Features.SocketFeature.GetAllSockets;
using Tech_Inventory.Application.Features.SocketFeature.GetOneSocket;
using Tech_Inventory.Application.Features.SocketFeature.UpdateSocket;

namespace Tech_Inventory.WebApi.Controllers;

public class SocketsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllSocketsRequest request)
    {
        return await Mediator.Send(request);
    }
    
    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneSocketRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateSocketRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateSocketRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteSocketRequest request)
    {
        return await Mediator.Send(request);
    }
}
