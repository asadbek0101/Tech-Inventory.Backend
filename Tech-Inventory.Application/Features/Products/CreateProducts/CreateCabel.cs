namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateCabel
{
    public int CabelTypeId { get; set; }
    public int ModelId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
