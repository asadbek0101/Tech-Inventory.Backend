using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.CreateHook;

public sealed record CreateHookRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
    public HookTypes HookType { get; set; }
}
