using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektLocations;

public sealed record GetLocationsRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; } = 0;
    public int DistrictId { get; set; } = 0;
    public int StreetId { get; set; } = 0;
    public int ProjectId { get; set; } = 0;
    public int OrderId { get; set; } = 0;
    public int ClassTypeId { get; set; } = 0;
    public int ClassId { get; set; } = 0;
    public string? SearchValue { get; set; }
}
