namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateBracket
{
    public int ModelId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
