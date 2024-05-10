using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CameraFeature.GetOneCamera;

public class GetOneCameraMapper : Profile
{
    public GetOneCameraMapper()
    {
        CreateMap<Camera, GetOneCameraResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
