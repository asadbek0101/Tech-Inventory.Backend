using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StreetFeature.GetStreetsList;

public sealed record GetStreetsListRequest : IRequest<ApiResponse>
{
    public int DistrictId { get; set; }
}
