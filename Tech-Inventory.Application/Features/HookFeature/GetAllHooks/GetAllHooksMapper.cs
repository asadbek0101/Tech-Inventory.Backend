using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.GetAllHooks;

public class GetAllHooksMapper : Profile
{
    public GetAllHooksMapper()
    {
        CreateMap<Hook, GetAllHooksResponse>();
    }
}
