namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateServer
{
    public int? Id { get; set; }
    public string Ip { get; set; }
    public string? Info { get; set; }
}
