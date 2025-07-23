namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record VideoRecorderResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
