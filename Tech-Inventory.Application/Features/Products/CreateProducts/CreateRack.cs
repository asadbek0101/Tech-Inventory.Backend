using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateRack
{
    public string NumberOfFibers { get; set; }
    public string TypeOfAdapter { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public RackTypes RackType { get; set; }
}
