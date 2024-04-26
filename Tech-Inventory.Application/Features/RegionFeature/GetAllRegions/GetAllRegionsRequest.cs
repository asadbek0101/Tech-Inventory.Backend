using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RegionFeature.GetAllRegions;

public sealed record GetAllRegionsRequest : IRequest<ApiResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? SearchValue { get; set; }
}
