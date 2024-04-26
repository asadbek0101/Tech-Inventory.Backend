using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CableFeature.GetAllCabels;

public class GetAllCabelsMapper : Profile
{
    public GetAllCabelsMapper()
    {
        CreateMap<Cabel, GetAllCabelsResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
