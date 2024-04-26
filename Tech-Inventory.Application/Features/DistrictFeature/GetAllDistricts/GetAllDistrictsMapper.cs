using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetAllDistricts;

public class GetAllDistrictsMapper : Profile
{
    public GetAllDistrictsMapper()
    {
        CreateMap<District, GetAllDistrictsResponse>().ForMember(res=>res.RegionName, otp => otp.MapFrom(d=>d.Region.Name));
    }
}
