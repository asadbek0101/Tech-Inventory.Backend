using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StanchionFeature.GetOneStanchion;

public class GetOneStanchionMapper : Profile
{
    public GetOneStanchionMapper()
    {
        CreateMap<Stanchion, GetOneStanchionResponse>()
            .ForMember(x => x.StanchionType, opt=>opt.MapFrom(x => x.Model.Name));
    }
}
