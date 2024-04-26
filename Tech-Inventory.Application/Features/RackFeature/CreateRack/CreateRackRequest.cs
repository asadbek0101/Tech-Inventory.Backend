using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RackFeature.CreateRack;

public sealed record CreateRackRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string NumberOfFibers { get; set; }
    public string TypeOfAdapter { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public RackTypes RackType { get; set; }
}
