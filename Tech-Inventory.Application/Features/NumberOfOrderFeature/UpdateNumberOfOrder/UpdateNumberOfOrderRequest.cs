using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.UpdateNumberOfOrder;

public class UpdateNumberOfOrderRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int RegionId { get; set; }
    public int? DistrictId { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
}
