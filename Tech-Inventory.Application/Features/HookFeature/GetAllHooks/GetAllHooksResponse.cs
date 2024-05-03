using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.GetAllHooks;

public sealed record GetAllHooksResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
    public HookTypes HookType { get; set; }
}
