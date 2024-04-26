using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CableFeature.GetOneCabel;

public sealed record GetOneCabelRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
