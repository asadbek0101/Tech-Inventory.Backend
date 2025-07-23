namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateStanchion
{
    public int StanchionTypeId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
