namespace Tech_Inventory.Application.Features.DistrictFeature.GetDistrictsList;

public sealed record GetDistrictsListResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
