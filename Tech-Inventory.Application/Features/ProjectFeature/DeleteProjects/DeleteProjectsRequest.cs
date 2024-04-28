using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectFeature.DeleteProjects;

public sealed record DeleteProjectsRequest : IRequest<ApiResponse>
{
    public List<int> ProjectIds { get; set; }
}
