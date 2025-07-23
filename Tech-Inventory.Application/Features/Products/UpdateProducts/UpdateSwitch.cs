using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateSwitch
{
    public int ModelId { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public SwitchTypes SwitchType { get; set; }
}
