namespace Tech_Inventory.Application.Features.RegionFeature.GetAllRegions;

public sealed record GetAllRegionsResponse
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string Asadbek {  get; set; }
}
