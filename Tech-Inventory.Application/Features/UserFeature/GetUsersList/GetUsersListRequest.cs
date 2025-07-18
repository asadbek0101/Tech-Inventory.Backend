using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.UserFeature.GetUsersList;

public sealed record GetUsersListRequest : IRequest<ApiResponse>
{
}
