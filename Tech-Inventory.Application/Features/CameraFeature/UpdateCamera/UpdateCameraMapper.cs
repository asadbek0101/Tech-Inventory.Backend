using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CameraFeature.UpdateCamera;

public class UpdateCameraMapper : Profile
{
    public UpdateCameraMapper()
    {
        CreateMap<UpdateCameraRequest, Camera>();
    }
}
