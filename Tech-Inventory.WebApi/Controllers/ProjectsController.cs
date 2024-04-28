using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ProjectFeature.CreateProject;
using Tech_Inventory.Application.Features.ProjectFeature.DeleteProjects;
using Tech_Inventory.Application.Features.ProjectFeature.GetAllProjects;
using Tech_Inventory.Application.Features.ProjectFeature.GetOneProject;
using Tech_Inventory.Application.Features.ProjectFeature.GetProjectsList;
using Tech_Inventory.Application.Features.ProjectFeature.UpdateProject;

namespace Tech_Inventory.WebApi.Controllers;

public class ProjectsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllProjectsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneProjectRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList()
    {
        return await Mediator.Send(new GetProjectsListRequest());
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateProjectRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateProjectRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Delete")]
    public async Task<ActionResult<ApiResponse>> DeleteByIds([FromBody] DeleteProjectsRequest request)
    {
        return await Mediator.Send(request);
    }
}
