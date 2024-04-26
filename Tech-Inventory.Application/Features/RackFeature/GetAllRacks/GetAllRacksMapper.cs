using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RackFeature.GetAllRacks;

public class GetAllRacksMapper : Profile
{
    public GetAllRacksMapper()
    {
        CreateMap<Rack, GetAllRacksResponse>();
    }
}
