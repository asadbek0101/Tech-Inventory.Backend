using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.CreateTerminalServer;

public sealed record CreateTerminalServerRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
}
