using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StanchionFeature.GetAllStanchions;

public sealed record GetAllStanchionsResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string StanchionType { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
