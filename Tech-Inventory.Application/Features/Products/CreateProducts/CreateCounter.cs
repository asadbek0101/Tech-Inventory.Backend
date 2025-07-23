namespace Tech_Inventory.Application.Features.Products.CreateProducts;

public sealed record CreateCounter
{
    public int ModelId { get; set; }
    public string NumberOfConcern { get; set; }
    public string? Info { get; set; }
}
