using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetAllModels;

public class GetAllModelsMapper : Profile
{
    public GetAllModelsMapper()
    {
        CreateMap<Model, GetAllModelsResponse>()
            .ForMember(x=>x.Type, otp => otp.MapFrom( x => x.Type.ToString()));
    }
}
