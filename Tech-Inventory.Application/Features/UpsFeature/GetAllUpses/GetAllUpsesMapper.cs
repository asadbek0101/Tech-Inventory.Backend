using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.UpsFeature.GetAllUpses;

public class GetAllUpsesMapper : Profile
{
    public GetAllUpsesMapper()
    {
        CreateMap<Ups, GetAllUpsesResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
