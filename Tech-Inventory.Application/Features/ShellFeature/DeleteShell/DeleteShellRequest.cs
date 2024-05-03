using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ShellFeature.DeleteShell;

public sealed record DeleteShellRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
