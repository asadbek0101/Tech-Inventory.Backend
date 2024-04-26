using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RegionFeature.UpdateRegion;

public class UpdateRegionMapper : Profile
{
    public UpdateRegionMapper()
    {
        CreateMap<UpdateRegionRequest, Region>();
    }
}
