namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateTerminalServer
{
    public int ModelId { get; set; }
    public string? Info { get; set; }
}
