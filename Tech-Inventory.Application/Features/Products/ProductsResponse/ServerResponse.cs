namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record ServerResponse
{
    public int Id { get; set; }
    public string Ip { get; set; }
    public string? Info { get; set; }
}
