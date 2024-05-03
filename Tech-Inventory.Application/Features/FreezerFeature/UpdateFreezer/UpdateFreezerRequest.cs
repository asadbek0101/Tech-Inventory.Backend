using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.FreezerFeature.UpdateFreezer;

public sealed record UpdateFreezerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
