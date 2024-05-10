using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.DeleteTerminalServer;

public sealed record DeleteTerminalServerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
