using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.FreezerFeature.GetOneFreezer;

public sealed record GetOneFreezerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
