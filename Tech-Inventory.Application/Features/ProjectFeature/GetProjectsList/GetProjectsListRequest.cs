using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetProjectsList;

public sealed record GetProjectsListRequest : IRequest<ApiResponse>
{
}
