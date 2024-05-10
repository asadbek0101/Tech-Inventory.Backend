using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.DeleteSpeedChecking;

public sealed record DeleteSpeedCheckingRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
