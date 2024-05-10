using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.GetOenTerminalServer;

public sealed record GetOneTerminalServerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
