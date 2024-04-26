using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DistrictFeature.DeleteDistrict;

public sealed record DeleteDistrictRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
