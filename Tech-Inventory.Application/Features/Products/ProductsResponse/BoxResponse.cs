namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record BoxResponse
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string Type { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
