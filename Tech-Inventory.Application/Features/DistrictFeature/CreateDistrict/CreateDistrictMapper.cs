using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DistrictFeature.CreateDistrict;

public class CreateDistrictMapper : Profile
{
    public CreateDistrictMapper()
    {
        CreateMap<CreateDistrictRequest, District>();
    }
}
