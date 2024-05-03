using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ConnectorFeature.GetOneConnector;

public sealed record GetOneConnectorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
