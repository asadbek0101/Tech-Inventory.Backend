using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record CameraResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string? Name { get; set; }
    public string SerialNumber { get; set; }
    public string Ip { get; set; }
    public string Status { get; set; }
    public string? Info { get; set; }
    public CameraTypes CameraType { get; set; }
}
