using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ConnectorFeature.DeleteConnector;

public sealed record DeleteConnectorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
