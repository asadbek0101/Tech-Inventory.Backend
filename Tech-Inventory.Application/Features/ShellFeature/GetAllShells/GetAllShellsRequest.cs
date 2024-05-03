using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.GetAllShells;

public sealed record GetAllShellsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public ShellTypes ShellType { get; set; }
}
