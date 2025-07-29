using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DashboardFeature.GetObjectsDashboard;

public sealed record GetObjectsDashboardRequest : IRequest<ApiResponse>
{
    public int RegionId { get; set; } = 0;
    public int ProjectId { get; set; } = 0;
    public int ClassTypeId { get; set; } = 0;
}
