using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.HookFeature.DeleteHook;

public sealed record DeleteHookRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
