namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record CounterResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string NumberOfConcern { get; set; }
    public string? Info { get; set; }
}
