using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.GetAllSpeedCheckings;

public class GetAllSpeedCheckingsMapper : Profile
{
    public GetAllSpeedCheckingsMapper()
    {
        CreateMap<SpeedChecking, GetAllSpeedCheckingsResponse>()
            .ForMember(x=>x.Model, otp=>otp.MapFrom(x=>x.Model.Name));
    }
}
