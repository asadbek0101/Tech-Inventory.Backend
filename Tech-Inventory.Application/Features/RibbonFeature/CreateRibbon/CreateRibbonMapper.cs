using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RibbonFeature.CreateRibbon;

public class CreateRibbonMapper : Profile
{
    public CreateRibbonMapper()
    {
        CreateMap<CreateRibbonRequest, Ribbon>();
    }
}
