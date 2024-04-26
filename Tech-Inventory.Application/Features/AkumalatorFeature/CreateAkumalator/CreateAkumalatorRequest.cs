using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.CreateAkumalator;

public sealed record CreateAkumalatorRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Power { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
