using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.CreateObyekt;

public sealed record CreateObyektRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int ProjectId { get; set; }
    public int NumberOfOrderId { get; set; }
    public int ObjectClassId { get; set; }
    public int ObjectClassTypeId { get; set; }
    public string Name { get; set; }
    public string Home { get; set; }
    public string Street { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string? Info { get; set; }
    public ConnectionTypes ConnectionType { get; set; }
}
