namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record NailResponse
{
    public int Id { get; set; }
    public string Weight { get; set; }
    public string? Info { get; set; }
}
