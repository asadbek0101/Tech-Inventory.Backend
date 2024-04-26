using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.GetAllSvetafors;

public class GetAllSvetaforsMapper : Profile
{
    public GetAllSvetaforsMapper()
    {
        CreateMap<SvetoforDetector, GetAllSvetaforsResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
