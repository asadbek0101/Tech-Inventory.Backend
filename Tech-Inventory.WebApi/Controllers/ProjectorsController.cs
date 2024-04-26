using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ProjectorFeature.CreateProjector;
using Tech_Inventory.Application.Features.ProjectorFeature.DeleteProjector;
using Tech_Inventory.Application.Features.ProjectorFeature.GetAllProjectors;
using Tech_Inventory.Application.Features.ProjectorFeature.GetOneProjector;
using Tech_Inventory.Application.Features.ProjectorFeature.UpdateProjector;

namespace Tech_Inventory.WebApi.Controllers;

public class ProjectorsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllProjectorsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneProjectorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateProjectorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateProjectorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteProjectorRequest request)
    {
        return await Mediator.Send(request);
    }
}
