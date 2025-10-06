namespace Tech_Inventory.Application.Features.Products.UpdateProducts;

public sealed record UpdateCounter
{
    public int Id { get; set; } 
    public int ModelId { get; set; }
    public string NumberOfConcern { get; set; }
    public string? Info { get; set; }
}
