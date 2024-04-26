using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetAllObyekts;

public class GetAllObyektsMapper : Profile
{
    public GetAllObyektsMapper()
    {
        CreateMap<Obyekt, GetAllObyektsResponse>()
            .ForMember(x=>x.ConnectionType, otp=>otp.MapFrom(x => x.ConnectionType.ToString()));
    }
}
