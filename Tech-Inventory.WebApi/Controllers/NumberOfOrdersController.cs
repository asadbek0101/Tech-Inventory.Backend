using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.NumberOfOrderFeature.CreateNumberOfOrder;
using Tech_Inventory.Application.Features.NumberOfOrderFeature.DeleteNumberOfOrder;
using Tech_Inventory.Application.Features.NumberOfOrderFeature.GetAllNumberOfOrder;
using Tech_Inventory.Application.Features.NumberOfOrderFeature.GetNumberOfOrdersList;
using Tech_Inventory.Application.Features.NumberOfOrderFeature.GetOneNumberOfOrder;
using Tech_Inventory.Application.Features.NumberOfOrderFeature.UpdateNumberOfOrder;

namespace Tech_Inventory.WebApi.Controllers;

public class NumberOfOrdersController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllNumberOfOrdersRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<ApiResponse>> GetList([FromQuery] GetNumberOfOrdersListRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneNumberOfOrderRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateNumberOfOrderRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateNumberOfOrderRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteNumberOfOrderRequest request)
    {
        return await Mediator.Send(request);
    }
}
