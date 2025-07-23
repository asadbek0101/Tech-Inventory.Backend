using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record SvetaforResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
}
