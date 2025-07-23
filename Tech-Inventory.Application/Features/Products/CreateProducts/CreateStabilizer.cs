namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateStabilizer
{
    public int ModelId { get; set; }
    public string Power { get; set; }
    public string? Info { get; set; }
}
