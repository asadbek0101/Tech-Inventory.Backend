using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RegionFeature.GetOneRegion;

public sealed record GetOneRegionRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
