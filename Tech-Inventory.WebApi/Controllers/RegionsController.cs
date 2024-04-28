using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.RegionFeature.CreateRegion;
using Tech_Inventory.Application.Features.RegionFeature.DeleteRegion;
using Tech_Inventory.Application.Features.RegionFeature.DeleteRegions;
using Tech_Inventory.Application.Features.RegionFeature.GetAllRegions;
using Tech_Inventory.Application.Features.RegionFeature.GetOneRegion;
using Tech_Inventory.Application.Features.RegionFeature.GetRegionsList;
using Tech_Inventory.Application.Features.RegionFeature.UpdateRegion;

namespace Tech_Inventory.WebApi.Controllers;

[Authorize]
public class RegionsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllRegionsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList()
    {
        return await Mediator.Send(new GetRegionsListRequest());
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneRegionRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateRegionRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Delete")]
    public async Task<ActionResult<ApiResponse>> DeleteByIds([FromBody] DeleteRegionsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateRegionRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteRegionRequest request)
    {
        return await Mediator.Send(request);
    }
}
