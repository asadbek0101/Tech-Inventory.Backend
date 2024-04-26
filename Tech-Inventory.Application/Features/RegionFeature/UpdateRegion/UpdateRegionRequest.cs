using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RegionFeature.UpdateRegion;

public sealed record UpdateRegionRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
