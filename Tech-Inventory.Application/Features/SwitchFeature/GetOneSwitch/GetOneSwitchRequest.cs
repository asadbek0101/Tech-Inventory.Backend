using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SwitchFeature.GetOneSwitch;

public sealed record GetOneSwitchRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
