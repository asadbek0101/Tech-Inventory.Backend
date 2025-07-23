using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateRack
{
    public string NumberOfFibers { get; set; }
    public string TypeOfAdapter { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public RackTypes RackType { get; set; }
}
