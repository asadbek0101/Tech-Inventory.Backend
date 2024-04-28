using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RoleFeature.GetRolesList;

public sealed record GetRolesListRequest : IRequest<ApiResponse>
{
}
