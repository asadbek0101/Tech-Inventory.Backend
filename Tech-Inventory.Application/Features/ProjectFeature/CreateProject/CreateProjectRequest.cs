using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectFeature.CreateProject;

public sealed record CreateProjectRequest : IRequest<ApiResponse>
{
    public string Name { get; set; }
    public string? Info { get; set; }
}
