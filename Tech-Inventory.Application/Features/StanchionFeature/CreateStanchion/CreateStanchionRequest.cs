using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StanchionFeature.CreateStanchion;

public sealed record CreateStanchionRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int StanchionTypeId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
