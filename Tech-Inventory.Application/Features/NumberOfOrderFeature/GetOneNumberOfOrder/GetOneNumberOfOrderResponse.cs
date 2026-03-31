namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetOneNumberOfOrder;

public sealed record GetOneNumberOfOrderResponse
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
}
