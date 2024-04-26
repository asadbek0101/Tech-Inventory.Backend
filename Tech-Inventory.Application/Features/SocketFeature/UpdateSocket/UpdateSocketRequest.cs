using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SocketFeature.UpdateSocket;

public sealed record UpdateSocketRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Info { get; set; }
}
