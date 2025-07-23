namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateCabel
{
    public int CabelTypeId { get; set; }
    public int ModelId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
