using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DistrictFeature.DeleteDistricts;

public sealed record DeleteDistrictsRequest : IRequest<ApiResponse>
{
    public List<int> DistrictIds { get; set; }
}
