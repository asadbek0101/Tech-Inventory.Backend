using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RegionFeature.CreateRegion;

public class CreateRegionMapper : Profile
{
    public CreateRegionMapper()
    {
        CreateMap<CreateRegionRequest, Region>();
    }
}
