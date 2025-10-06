namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateFreezer
{
    public int Id { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
