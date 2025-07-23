using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.DashboardFeature.GetDashboard;

public sealed record GetDashboardRequest : IRequest<ApiResponse>
{

}
