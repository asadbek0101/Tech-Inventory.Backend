using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.CameraFeature.DeleteCamera;

public sealed record DeleteCameraRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
