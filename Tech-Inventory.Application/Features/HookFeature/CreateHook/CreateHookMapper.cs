using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.CreateHook;

public class CreateHookMapper : Profile
{
    public CreateHookMapper()
    {
        CreateMap<CreateHookRequest, Hook>();
    }
}
