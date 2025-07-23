namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record ConnectorResponse
{
    public int Id { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
