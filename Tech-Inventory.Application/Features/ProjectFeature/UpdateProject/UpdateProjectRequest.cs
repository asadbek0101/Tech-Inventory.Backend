using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectFeature.UpdateProject;

public sealed record UpdateProjectRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
}
