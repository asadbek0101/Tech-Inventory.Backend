using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RegionFeature.GetRegionsList;

public class GetRegionsListMapper : Profile
{
    public GetRegionsListMapper()
    {
        CreateMap<Region, GetRegionsListResponse>();
    }
}
