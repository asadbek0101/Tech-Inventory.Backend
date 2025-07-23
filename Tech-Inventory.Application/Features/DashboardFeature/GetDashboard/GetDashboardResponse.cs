namespace Tech_Inventory.Application.Features.DashboardFeature.GetDashboard;

public sealed record GetDashboardResponse
{
    public List<GetDashboardDto> Classifications { get; set; }
    public List<GetDashboardDto> Cameras { get; set; }
    public List<GetDashboardDto> Regions { get; set; }
    public List<GetDashboardDto> Users { get; set; }
}
