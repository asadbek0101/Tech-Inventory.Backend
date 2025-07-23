namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record RibbonResponse
{
    public int Id { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
