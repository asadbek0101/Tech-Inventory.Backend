using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.CreateNumberOfOrder;

public sealed record CreateNumberOfOrderRequest : IRequest<ApiResponse>
{
    public int ProjectId { get; set; }
    public int RegionId { get; set; }
    public int? DistrictId { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
}
