using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.UpdateHook;

public sealed record UpdateHookRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
    public HookTypes HookType { get; set; }
}
