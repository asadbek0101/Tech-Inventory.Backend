using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.FreezerFeature.DeleteFreezer;

public sealed record DeleteFreezerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
