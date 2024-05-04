using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetModelsList;

public class GetModelsListMapper : Profile
{
    public GetModelsListMapper()
    {
        CreateMap<Model, GetModelsListResponse>()
            .ForMember(x=>x.Name, otp=>otp.MapFrom(x => x.Info != "" ? x.Name + "(" + x.Info + ")" : x.Name));
    }
}
