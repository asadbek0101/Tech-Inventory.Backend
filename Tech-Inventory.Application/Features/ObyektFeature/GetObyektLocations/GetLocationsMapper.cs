using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektLocations;

public class GetLocationsMapper : Profile
{
    public GetLocationsMapper()
    {
        CreateMap<Obyekt, GetLocationsResponse>();
    }
}
