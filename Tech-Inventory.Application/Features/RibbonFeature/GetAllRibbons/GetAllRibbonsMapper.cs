using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RibbonFeature.GetAllRibbons;

public class GetAllRibbonsMapper : Profile
{
    public GetAllRibbonsMapper()
    {
        CreateMap<Ribbon, GetAllRibbonsResponse>();
    }
}
    
