using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ServerFeature.GetOneServer;

public sealed record GetOneServerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
