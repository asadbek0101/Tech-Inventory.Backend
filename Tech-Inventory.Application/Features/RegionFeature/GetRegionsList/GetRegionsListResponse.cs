namespace Tech_Inventory.Application.Features.RegionFeature.GetRegionsList;

public sealed record GetRegionsListResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double? Lat { get; set; }
    public double? Lng { get; set; }
    public int? Zoom { get; set; }
}
