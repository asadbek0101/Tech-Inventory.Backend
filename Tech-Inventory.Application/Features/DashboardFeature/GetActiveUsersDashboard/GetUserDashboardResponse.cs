using Tech_Inventory.Application.Features.DashboardFeature.GetObjectsDashboard;

namespace Tech_Inventory.Application.Features.DashboardFeature.GetActiveUsersDashboard;

public sealed record GetUserDashboardResponse
{
    public List<GetObjectsDashboardDto> Users { get; set; }
}
