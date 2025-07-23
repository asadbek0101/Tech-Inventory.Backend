using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.Products.ProductsResponse;

public sealed record RackResponse
{
    public int Id { get; set; }
    public string NumberOfFibers { get; set; }
    public string TypeOfAdapter { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
}
