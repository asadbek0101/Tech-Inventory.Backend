using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ProjectorFeature.GetOneProjector;

public sealed record GetOneProjectorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
