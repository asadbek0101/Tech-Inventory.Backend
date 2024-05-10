using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.GetOneSpeedChecking;

public class GetOneSpeedCheckingMapper : Profile
{
    public GetOneSpeedCheckingMapper()
    {
        CreateMap<SpeedChecking, GetOneSpeedCheckingResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
