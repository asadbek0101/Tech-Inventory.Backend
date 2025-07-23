namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record SpeedCheckingResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string SerialNumber { get; set; }
    public string? Info { get; set; }
}
