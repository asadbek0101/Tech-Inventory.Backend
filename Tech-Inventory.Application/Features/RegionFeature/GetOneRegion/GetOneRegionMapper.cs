using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RegionFeature.GetOneRegion;

public class GetOneRegionMapper : Profile
{
    public GetOneRegionMapper()
    {
        CreateMap<Region, GetOneRegionResponse>();
    }
}
