using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetDistrictsList;

public class GetDistrictsListMapper : Profile
{
    public GetDistrictsListMapper()
    {
        CreateMap<District, GetDistrictsListResponse>();
    }
}
