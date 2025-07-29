namespace Tech_Inventory.Application.Features.DashboardFeature.GetObjectsDashboard;

public sealed record GetObjectsDashboardResponse
{
    public List<GetObjectsDashboardDto> Classifications { get; set; }
    public List<GetObjectsDashboardDto> Projects { get; set; }
    public List<GetObjectsDashboardDto> Regions { get; set; }

    public string RegionTitle { get; set; }
    public string ProjectTitle { get; set; }
    public string ClassTitle { get; set; }
   
}
