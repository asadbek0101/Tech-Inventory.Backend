using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SwitchFeature.GetOneSwitch;

public class GetOneSwitchMapper : Profile
{
    public GetOneSwitchMapper()
    {
        CreateMap<Switch, GetOneSwitchResponse>();
    }
}
