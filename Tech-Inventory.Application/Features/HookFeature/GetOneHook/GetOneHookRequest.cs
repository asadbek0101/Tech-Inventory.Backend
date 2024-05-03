using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.HookFeature.GetOneHook;

public sealed record GetOneHookRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
