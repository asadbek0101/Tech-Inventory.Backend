using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RibbonFeature.GetAllRibbons;

public sealed record GetAllRibbonsResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
