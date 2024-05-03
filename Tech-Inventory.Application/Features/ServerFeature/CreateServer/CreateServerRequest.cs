using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ServerFeature.CreateServer;

public sealed record CreateServerRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Ip { get; set; }
    public string? Info { get; set; }
}
