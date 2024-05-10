using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.FreezerFeature.GetAllFreezers;

public sealed record GetAllFreezersResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
