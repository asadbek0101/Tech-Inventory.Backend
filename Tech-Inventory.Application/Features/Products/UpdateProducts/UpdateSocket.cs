namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateSocket
{
    public int ModelId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
