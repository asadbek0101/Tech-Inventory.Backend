using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SwitchFeature.CreateSwitch;

public sealed record CreateSwitchRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public SwitchTypes SwitchType { get; set; }
}
