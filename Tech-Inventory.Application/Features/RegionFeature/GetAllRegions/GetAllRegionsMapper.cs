using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RegionFeature.GetAllRegions;

public class GetAllRegionsMapper : Profile
{
    public GetAllRegionsMapper()
    {
        CreateMap<Region, GetAllRegionsResponse>();
    }
}
