using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.FreezerFeature.GetOneFreezer;

public class GetOneFreezerMapper : Profile
{
    public GetOneFreezerMapper()
    {
        CreateMap<Freezer, GetOneFreezerResponse>();
    }
}
