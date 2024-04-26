using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObyektFeature.UpdateObyekt;

public sealed record UpdateObyektRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int ProjectId { get; set; }
    public int? NumberOfOrderId { get; set; }
    public int ObjectClassificationId { get; set; }
    public int ObjectClassificationTypeId { get; set; }
    public string Name { get; set; }
    public string Home { get; set; }
    public string Street { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Info { get; set; }
}
