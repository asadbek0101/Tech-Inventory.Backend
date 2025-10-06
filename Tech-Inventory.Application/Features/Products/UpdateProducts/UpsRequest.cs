namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateUps
{
    public int? Id { get; set; }
    public int ModelId { get; set; }
    public string Power { get; set; }
    public string? Info { get; set; }
}
