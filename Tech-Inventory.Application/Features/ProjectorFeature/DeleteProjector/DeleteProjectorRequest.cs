using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectorFeature.DeleteProjector;

public sealed record DeleteProjectorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
