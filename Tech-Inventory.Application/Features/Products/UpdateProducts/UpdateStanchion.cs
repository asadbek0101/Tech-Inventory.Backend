namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateStanchion
{
    public int StanchionTypeId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
