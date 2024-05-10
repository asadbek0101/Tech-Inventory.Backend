using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.GetOneSvetafor;

public class GetOneSvetaforMapper : Profile
{
    public GetOneSvetaforMapper()
    {
        CreateMap<SvetoforDetector, GetOneSvetaforResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
