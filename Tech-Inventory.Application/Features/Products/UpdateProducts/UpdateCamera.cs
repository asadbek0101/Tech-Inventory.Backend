using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateCamera
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string? Name { get; set; }
    public string SerialNumber { get; set; }
    public string Ip { get; set; }
    public string Status { get; set; }
    public string? Info { get; set; }
    public CameraTypes CameraType { get; set; }
}
