using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetOneDistrict;

public sealed record GetOneDistrictRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
