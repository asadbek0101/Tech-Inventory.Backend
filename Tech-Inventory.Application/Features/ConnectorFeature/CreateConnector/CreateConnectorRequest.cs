using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ConnectorFeature.CreateConnector;

public sealed record CreateConnectorRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
