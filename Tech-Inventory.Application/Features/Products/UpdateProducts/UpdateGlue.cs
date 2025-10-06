namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateGlue
{
    public int Id { get; set; }
    public string CountOfCrate { get; set; }
    public string? Info { get; set; }
}
