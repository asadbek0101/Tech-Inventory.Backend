namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record SocketResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
