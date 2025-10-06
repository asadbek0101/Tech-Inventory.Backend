namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateStanchion
{
    public int? Id { get; set; }
    public int StanchionTypeId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
