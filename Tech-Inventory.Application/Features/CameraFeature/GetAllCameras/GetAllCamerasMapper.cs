using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CameraFeature.GetAllCameras;

public class GetAllCamerasMapper : Profile
{
    public GetAllCamerasMapper()
    {
        CreateMap<Camera, GetAllCamerasResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
