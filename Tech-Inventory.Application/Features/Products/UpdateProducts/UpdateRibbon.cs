namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateRibbon
{
    public int Id { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
