using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RackFeature.GetOneRack;

public sealed record GetOneRackRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
