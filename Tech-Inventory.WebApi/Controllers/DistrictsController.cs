using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.DistrictFeature.CreateDistrict;
using Tech_Inventory.Application.Features.DistrictFeature.DeleteDistrict;
using Tech_Inventory.Application.Features.DistrictFeature.DeleteDistricts;
using Tech_Inventory.Application.Features.DistrictFeature.GetAllDistricts;
using Tech_Inventory.Application.Features.DistrictFeature.GetDistrictsList;
using Tech_Inventory.Application.Features.DistrictFeature.GetOneDistrict;
using Tech_Inventory.Application.Features.DistrictFeature.UpdateDistrict;

namespace Tech_Inventory.WebApi.Controllers;

public class DistrictsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllDistrictsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList([FromQuery] GetDistrictsListRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneDistrictRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateDistrictRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Delete")]
    public async Task<ActionResult<ApiResponse>> DeleteByIds([FromBody] DeleteDistrictsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateDistrictRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteDistrictRequest request)
    {
        return await Mediator.Send(request);
    }
}
