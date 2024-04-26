using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RegionFeature.DeleteRegions;

public sealed record DeleteRegionsRequest : IRequest<ApiResponse>
{
    public List<int> RegionIds { get; set; }
}
