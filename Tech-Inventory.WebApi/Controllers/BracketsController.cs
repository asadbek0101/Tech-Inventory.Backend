using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.BracketFeature.CreateBracket;
using Tech_Inventory.Application.Features.BracketFeature.DeleteBracket;
using Tech_Inventory.Application.Features.BracketFeature.GetAllBrackets;
using Tech_Inventory.Application.Features.BracketFeature.GetOneBracket;
using Tech_Inventory.Application.Features.BracketFeature.UpdateBracket;

namespace Tech_Inventory.WebApi.Controllers;

public class BracketsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllBracketsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneBracketRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateBracketRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateBracketRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteBracketRequest request)
    {
        return await Mediator.Send(request);
    }
}
