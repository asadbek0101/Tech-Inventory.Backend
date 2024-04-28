using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetOneProject;

public sealed record GetOneProjectRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
