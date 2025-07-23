namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record StabilizerResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string Power { get; set; }
    public string? Info { get; set; }
}
