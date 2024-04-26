using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetOneModel;

public class GetOneModelMapper : Profile
{
    public GetOneModelMapper()
    {
        CreateMap<Model, GetOneModelResponse>()
            .ForMember(x=>x.Type, otp=>otp.MapFrom(x => x.Type.ToString()))
            .ForMember(x=>x.TypeId, otp=>otp.MapFrom(x => x.Type));
    }
}
