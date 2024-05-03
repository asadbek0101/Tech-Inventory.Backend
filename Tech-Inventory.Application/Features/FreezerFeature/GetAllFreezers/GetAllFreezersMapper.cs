using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.FreezerFeature.GetAllFreezers;

public class GetAllFreezersMapper : Profile
{
    public GetAllFreezersMapper()
    {
        CreateMap<Freezer, GetAllFreezersResponse>();
    }
}
