using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.GetOneSpeedChecking;

public sealed record GetOneSpeedCheckingRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
