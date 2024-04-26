using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SwitchFeature.GetAllSwitches;

public class GetAllSwitchesMapper : Profile
{
    public GetAllSwitchesMapper()
    {
        CreateMap<Switch, GetAllSwitchesResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
