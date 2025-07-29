using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DashboardFeature.GetActiveUsersDashboard;

public sealed record GetUserDashboardRequest : IRequest<ApiResponse>
{
}
