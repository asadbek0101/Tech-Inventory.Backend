using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ProjectFeature.CreateProject;
using Tech_Inventory.Application.Features.ProjectFeature.GetAllProjects;
using Tech_Inventory.Application.Features.ProjectFeature.GetProjectsList;

namespace Tech_Inventory.WebApi.Controllers;

public class ProjectsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllProjectsRequest request)
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
}
