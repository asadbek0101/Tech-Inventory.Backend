using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.GetOneHook;

public class GetOneHookMapper : Profile
{
    public GetOneHookMapper()
    {
        CreateMap<Hook, GetOneHookResponse>();
    }
}
