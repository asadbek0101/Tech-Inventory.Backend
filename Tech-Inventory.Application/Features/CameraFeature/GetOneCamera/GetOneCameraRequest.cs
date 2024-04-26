using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CameraFeature.GetOneCamera;

public sealed record GetOneCameraRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
