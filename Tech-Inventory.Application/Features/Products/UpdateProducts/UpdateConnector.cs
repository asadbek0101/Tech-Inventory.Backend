namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateConnector
{
    public int? Id { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
