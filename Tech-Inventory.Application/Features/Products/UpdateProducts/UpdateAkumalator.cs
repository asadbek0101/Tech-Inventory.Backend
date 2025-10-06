namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateAkumalator
{
    public int Id { get; set; }
    public string Power { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
