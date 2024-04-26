using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RegionFeature.DeleteRegion;

public sealed record DeleteRegionRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
