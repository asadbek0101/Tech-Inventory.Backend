using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DistrictFeature.CreateDistrict;

public sealed record CreateDistrictRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
