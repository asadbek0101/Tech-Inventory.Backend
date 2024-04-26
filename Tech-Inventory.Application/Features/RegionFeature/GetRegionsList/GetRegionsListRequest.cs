using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RegionFeature.GetRegionsList;

public sealed record GetRegionsListRequest : IRequest<ApiResponse>
{
}
