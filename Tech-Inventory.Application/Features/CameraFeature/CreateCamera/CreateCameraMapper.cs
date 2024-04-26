using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CameraFeature.CreateCamera;

public class CreateCameraMapper : Profile
{
    public CreateCameraMapper()
    {
        CreateMap<CreateCameraRequest, Camera>();
    }
}
