using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetOneShelf;

public sealed record GetOneShelfResponse
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public string Number { get; set; }
    public string Brand { get; set; }
    public string? Info { get; set; }
    public ShelfTypes ShelfType { get; set; }
}
