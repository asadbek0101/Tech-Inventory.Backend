using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.UpdateHook;

public class UpdateHookMapper : Profile
{
    public UpdateHookMapper()
    {
        CreateMap<UpdateHookRequest, Hook>();
    }
}
