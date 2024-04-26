using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.CreateSpeedChecking;

public sealed record CreateSpeedCheckingRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string SerialNumber { get; set; }
    public string? Info { get; set; }
}
