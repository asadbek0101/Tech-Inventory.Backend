using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.GetAllMountingBoxes;

public sealed record GetAllMountingBoxesResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
