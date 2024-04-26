using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetDistrictsList;

public sealed record GetDistrictsListRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; }
}
