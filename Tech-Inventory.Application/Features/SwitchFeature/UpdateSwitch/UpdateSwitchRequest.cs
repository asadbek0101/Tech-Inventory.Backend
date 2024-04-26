using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SwitchFeature.UpdateSwitch;

public sealed record UpdateSwitchRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int SwitchTypeId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string PortNumber { get; set; }
    public string Info { get; set; }
}
