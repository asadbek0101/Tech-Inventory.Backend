using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record ShelfResponse
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Brand { get; set; }
    public string SerialNumber { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
}
