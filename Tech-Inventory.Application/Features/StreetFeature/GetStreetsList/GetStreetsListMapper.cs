using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StreetFeature.GetStreetsList;

public class GetStreetsListMapper : Profile
{
    public GetStreetsListMapper()
    {
        CreateMap<Street, GetStreetsListResponse>();
    }
}
