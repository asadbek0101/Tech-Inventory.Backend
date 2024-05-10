using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.UpdateMountingBox;

public sealed record UpdateMountingBoxRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
