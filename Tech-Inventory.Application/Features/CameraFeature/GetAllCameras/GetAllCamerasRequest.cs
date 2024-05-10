using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CameraFeature.GetAllCameras;

public sealed record GetAllCamerasRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int PageCount { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public CameraTypes CameraType { get; set; }
}
