using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektLocations;

public sealed record GetLocationsRequest : IRequest<ApiResponse>
{
    public int? RegionId { get; set; }
    public int? ProjectId { get; set; }
    public int? ClassId { get; set; }
}
