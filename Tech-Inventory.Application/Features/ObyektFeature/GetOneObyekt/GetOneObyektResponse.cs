using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;

public sealed record GetOneObyektResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int ProjectId { get; set; }
    public int NumberOfOrderId { get; set; }
    public int ObjectClassificationId { get; set; }
    public int ObjectClassificationTypeId { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string Project { get; set; }
    public string NumberOfOrder { get; set; }
    public string ObjectClass { get; set; }
    public string ObjectClassType { get; set; }
    public string Name { get; set; }
    public string Home { get; set; }
    public string Street { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Info { get; set; }
    public int ConnectionTypeId { get; set; }
    public string ConnectionType { get; set; }
    public string Model { get; set; }
    public int ModelId { get; set; }
    public string SerialNumber { get; set; }
    public string NumberOfPort { get; set; }
    public string PhoneNumber { get; set; }

}
