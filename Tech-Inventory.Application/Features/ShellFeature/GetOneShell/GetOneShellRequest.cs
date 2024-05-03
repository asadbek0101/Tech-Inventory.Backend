using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ShellFeature.GetOneShell;

public sealed record GetOneShellRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
