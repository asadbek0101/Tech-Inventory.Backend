namespace Tech_Inventory.Application.Features.DistrictFeature.GetOneDistrict;

public sealed record GetOneDistrictResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
