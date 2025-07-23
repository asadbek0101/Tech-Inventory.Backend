namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record StanchionResponse
{
    public int Id { get; set; }
    public int StanchionTypeId { get; set; }
    public string StanchionType { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
