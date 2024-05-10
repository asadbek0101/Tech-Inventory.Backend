using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StabilizerFeature.UpdateStabilizer;

public sealed record UpdateStabilizerRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Power { get; set; }
    public string? Info { get; set; }
}
