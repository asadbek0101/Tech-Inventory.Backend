using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateSwitch
{
    public int ModelId { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public SwitchTypes SwitchType { get; set; }
}
