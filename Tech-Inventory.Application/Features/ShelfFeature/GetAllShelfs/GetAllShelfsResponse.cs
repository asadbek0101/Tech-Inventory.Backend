using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetAllShelfs;

public sealed record GetAllShelfsResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
}
