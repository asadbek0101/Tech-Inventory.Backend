using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ServerFeature.UpdateServer;

public sealed record UpdateServerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Ip { get; set; }
    public string? Info { get; set; }
}
