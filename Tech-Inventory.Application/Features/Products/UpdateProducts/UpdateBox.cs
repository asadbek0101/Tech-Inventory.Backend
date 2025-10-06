namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateBox
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
