using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SwitchFeature.DeleteSwitch;

public sealed record DeleteSwitchRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
