using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SocketFeature.DeleteSocket;

public sealed record DeleteSocketRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
