using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SwitchFeature.CreateSwitch;

public class CreateSwitchMapper : Profile
{
    public CreateSwitchMapper()
    {
        CreateMap<CreateSwitchRequest, Switch>();
    }
}
