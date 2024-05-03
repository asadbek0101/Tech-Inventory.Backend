using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RibbonFeature.UpdateRibbon;

public class UdpateRibbonMapper : Profile
{
    public UdpateRibbonMapper()
    {
        CreateMap<UpdateRibbonRequest, Ribbon>();
    }
}
