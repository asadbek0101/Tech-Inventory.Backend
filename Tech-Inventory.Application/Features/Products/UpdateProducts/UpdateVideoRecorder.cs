namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record UpdateVideoRecorder
{
    public int? Id { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
}
