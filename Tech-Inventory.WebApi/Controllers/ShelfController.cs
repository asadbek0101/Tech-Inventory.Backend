using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ShelfFeature.CreateShelf;
using Tech_Inventory.Application.Features.ShelfFeature.DeleteShelf;
using Tech_Inventory.Application.Features.ShelfFeature.GetAllShelfs;
using Tech_Inventory.Application.Features.ShelfFeature.GetOneShelf;
using Tech_Inventory.Application.Features.ShelfFeature.UpdateShelf;

namespace Tech_Inventory.WebApi.Controllers;

public class ShelfController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllShelfsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneShelfRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateShelfRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateShelfRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteShelfRequest request)
    {
        return await Mediator.Send(request);
    }
}
