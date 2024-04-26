using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SocketFeature.GetOneSocket;

public sealed record GetOneSocketRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
