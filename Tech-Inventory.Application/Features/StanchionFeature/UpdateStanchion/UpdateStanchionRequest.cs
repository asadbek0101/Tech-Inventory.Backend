using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StanchionFeature.UpdateStanchion;

public sealed record UpdateStanchionRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int StanchionTypeId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
