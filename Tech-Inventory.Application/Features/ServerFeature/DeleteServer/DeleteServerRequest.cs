using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ServerFeature.DeleteServer;

public sealed record DeleteServerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
