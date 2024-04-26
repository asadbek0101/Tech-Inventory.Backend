using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectorFeature.UpdateProjector;

public sealed record UpdateProjectorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ProjectorTypeId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string Model { get; set; }
}
