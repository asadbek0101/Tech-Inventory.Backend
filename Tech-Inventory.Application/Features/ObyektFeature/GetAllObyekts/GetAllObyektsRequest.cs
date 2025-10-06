using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetAllObyekts;

public sealed record GetAllObyektsRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; } = 0;
    public int DistrictId { get; set; } = 0;
    public int StreetId { get; set; } = 0;
    public int ProjectId { get; set; } = 0;
    public int NumberOfOrderId { get; set; } = 0;
    public int CreatedBy { get; set; } = 0;
    public int ObjectClassificationId { get; set; } = 0;
    public int ObjectClassificationTypeId { get; set; } = 0;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } =20;
    public string? SearchValue { get; set; }
}
