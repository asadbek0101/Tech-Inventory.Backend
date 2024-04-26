using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetAllDistricts;

public sealed record GetAllDistrictsRequest : IRequest<ApiResponse> 
{
    public int RegionId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
