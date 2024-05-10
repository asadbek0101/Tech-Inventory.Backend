namespace Tech_Inventory.Application.Features.DistrictFeature.GetAllDistricts;

public sealed record GetAllDistrictsResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string RegionName { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
    public string Creator { get; set; }
    public string Updator { get; set; }
}
