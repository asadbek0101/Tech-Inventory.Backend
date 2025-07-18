using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetAllObyekts;

public class GetAllObyektsMapper : Profile
{
    public GetAllObyektsMapper()
    {
        CreateMap<Obyekt, GetAllObyektsResponse>()
            .ForMember(x => x.ConnectionType, otp => otp.MapFrom(x => x.ConnectionType.ToString()))
            .ForMember(x => x.Region, otp => otp.MapFrom(x => x.Region.Name))
            .ForMember(x => x.District, otp => otp.MapFrom(x => x.District.Name))
            .ForMember(x => x.Street, otp => otp.MapFrom(x => x.Streett.Name))
            .ForMember(x => x.Project, otp => otp.MapFrom(x => x.Project.Name));
    }
}
