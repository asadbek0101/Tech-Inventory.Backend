using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.UpsFeature.GetOneUps;

public class GetOneUpsMapper : Profile
{
    public GetOneUpsMapper()
    {
        CreateMap<Ups, GetOneUpsReponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
