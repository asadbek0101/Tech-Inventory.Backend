using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.GetOneHook;

public sealed record GetOneHookResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
    public HookTypes HookType { get; set; }
}
