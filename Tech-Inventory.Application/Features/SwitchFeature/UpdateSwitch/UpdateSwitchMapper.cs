using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SwitchFeature.UpdateSwitch;

public class UpdateSwitchMapper : Profile
{
    public UpdateSwitchMapper()
    {
        CreateMap<UpdateSwitchRequest, Switch>();
    }
}
