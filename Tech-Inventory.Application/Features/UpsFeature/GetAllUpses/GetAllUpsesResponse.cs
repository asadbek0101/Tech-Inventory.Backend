using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UpsFeature.GetAllUpses;

public sealed record GetAllUpsesResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Power { get; set; }
    public string Info { get; set; }
}
