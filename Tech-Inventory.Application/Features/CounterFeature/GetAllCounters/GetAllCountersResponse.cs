using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CounterFeature.GetAllCounters;

public sealed record GetAllCountersResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
