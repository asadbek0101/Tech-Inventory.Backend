using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DistrictFeature.UpdateDistrict;

public sealed record UpdateDistrictRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
