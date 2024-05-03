using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RibbonFeature.GetOneRibbon;

public class GetOneRibbonMapper : Profile
{
    public GetOneRibbonMapper()
    {
        CreateMap<Ribbon, GetOneRibbonResponse>();
    }
}
