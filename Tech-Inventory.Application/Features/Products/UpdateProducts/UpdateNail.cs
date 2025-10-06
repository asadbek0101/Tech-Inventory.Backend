namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateNail
{
    public int? Id { get; set; }
    public string Weight { get; set; }
    public string? Info { get; set; }
}
