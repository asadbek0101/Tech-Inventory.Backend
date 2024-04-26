using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.AvtomatFeature.CreateAvtomat;
using Tech_Inventory.Application.Features.AvtomatFeature.DeleteAvtomat;
using Tech_Inventory.Application.Features.AvtomatFeature.GetAllAvtomats;
using Tech_Inventory.Application.Features.AvtomatFeature.GetOneAvtomat;
using Tech_Inventory.Application.Features.AvtomatFeature.UpdateAvtomat;

namespace Tech_Inventory.WebApi.Controllers;

public class AvtomatsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllAvtomatsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneAvtomatRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateAvtomatRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateAvtomatRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteAvtomatRequest request)
    {
        return await Mediator.Send(request);
    }
}
