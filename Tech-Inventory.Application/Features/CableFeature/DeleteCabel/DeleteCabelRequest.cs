using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CableFeature.DeleteCabel;

public sealed record DeleteCabelRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
