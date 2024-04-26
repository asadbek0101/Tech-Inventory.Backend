using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetOneDistrict;

public class GetOneDistrictMapper : Profile
{
    public GetOneDistrictMapper()
    {
        CreateMap<District, GetOneDistrictResponse>();
    }
}
