using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Features.ConnectorFeature.CreateConnector;
using Tech_Inventory.Application.Features.ConnectorFeature.DeleteConnector;
using Tech_Inventory.Application.Features.ConnectorFeature.GetAllConnectors;
using Tech_Inventory.Application.Features.ConnectorFeature.GetOneConnector;
using Tech_Inventory.Application.Features.ConnectorFeature.UpdateConnector;

namespace Tech_Inventory.WebApi.Controllers;

public class ConnectorsController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllConnectorsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("GetOne")]
    public async Task<ActionResult<ApiResponse>> GetOne([FromQuery] GetOneConnectorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateConnectorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateConnectorRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteConnectorRequest request)
    {
        return await Mediator.Send(request);
    }
}
