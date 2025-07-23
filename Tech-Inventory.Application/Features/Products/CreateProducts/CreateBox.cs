namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateBox
{
    public int TypeId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
