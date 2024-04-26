using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RackFeature.DeleteRack;

public sealed record DeleteRackRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
