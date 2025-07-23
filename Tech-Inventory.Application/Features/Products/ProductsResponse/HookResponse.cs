using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record HookResponse
{
    public int Id { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
