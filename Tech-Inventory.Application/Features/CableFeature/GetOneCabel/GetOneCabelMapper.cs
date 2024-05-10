using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CableFeature.GetOneCabel;

public class GetOneCabelMapper : Profile
{
    public GetOneCabelMapper()
    {
        CreateMap<Cabel, GetOneCabelResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
