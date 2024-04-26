using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.RackFeature.UpdateRack;

public sealed record UpdateRackRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int RackTypeId { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
}
