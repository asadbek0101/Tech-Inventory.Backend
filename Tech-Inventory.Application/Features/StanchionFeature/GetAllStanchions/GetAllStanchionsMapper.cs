using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StanchionFeature.GetAllStanchions;

public class GetAllStanchionsMapper : Profile
{
    public GetAllStanchionsMapper()
    {
        CreateMap<Stanchion, GetAllStanchionsResponse>()
            .ForMember(x => x.StanchionType, otp=>otp.MapFrom(x=>x.Model.Name));
    }
}
