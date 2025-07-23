using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateHook
{
    public string Count { get; set; }
    public string? Info { get; set; }
    public HookTypes HookType { get; set; }
}
