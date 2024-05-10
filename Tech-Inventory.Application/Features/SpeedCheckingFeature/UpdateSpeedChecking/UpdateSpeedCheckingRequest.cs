using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.UpdateSpeedChecking;

public sealed record UpdateSpeedCheckingRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string SerialNumber { get; set; }
    public string? Info { get; set; }
}
