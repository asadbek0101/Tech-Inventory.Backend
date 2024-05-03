using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ShellFeature.CreateShell;
using Tech_Inventory.Application.Features.ShellFeature.DeleteShell;
using Tech_Inventory.Application.Features.ShellFeature.GetAllShells;
using Tech_Inventory.Application.Features.ShellFeature.GetOneShell;
using Tech_Inventory.Application.Features.ShellFeature.UpdateShell;

namespace Tech_Inventory.WebApi.Controllers;

public class ShellsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllShellsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneShellRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateShellRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateShellRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteShellRequest request)
    {
        return await Mediator.Send(request);
    }
}
