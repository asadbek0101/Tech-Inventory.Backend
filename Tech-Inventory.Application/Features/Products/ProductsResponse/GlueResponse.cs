namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record GlueResponse
{
    public int Id { get; set; }
    public string CountOfCrate { get; set; }
    public string? Info { get; set; }
}
