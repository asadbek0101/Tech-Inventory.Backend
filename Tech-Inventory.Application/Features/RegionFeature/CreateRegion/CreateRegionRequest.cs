using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RegionFeature.CreateRegion;

public sealed record CreateRegionRequest : IRequest<ApiResponse>
{
    public string Name { get; set; }
    public string? Info { get; set; }
}
