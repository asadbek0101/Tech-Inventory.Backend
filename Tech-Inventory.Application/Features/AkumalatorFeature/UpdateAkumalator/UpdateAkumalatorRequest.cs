using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.UpdateAkumalator;

public sealed record UpdateAkumalatorRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Power { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
