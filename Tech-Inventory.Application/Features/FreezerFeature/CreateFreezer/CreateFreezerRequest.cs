using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.FreezerFeature.CreateFreezer;

public sealed record CreateFreezerRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
