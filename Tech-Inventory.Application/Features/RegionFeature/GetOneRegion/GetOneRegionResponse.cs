namespace Tech_Inventory.Application.Features.RegionFeature.GetOneRegion;

public sealed record GetOneRegionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
