namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateAvtomat
{
    public int ModelId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
