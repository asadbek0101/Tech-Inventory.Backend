using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.CreateShell;

public sealed record CreateShellRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
    public ShellTypes ShellType { get; set; }
}
