using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DistrictFeature.UpdateDistrict;

public class UpdateDistrictMapper : Profile
{
    public UpdateDistrictMapper()
    {
        CreateMap<UpdateDistrictRequest, District>();
    }
}
