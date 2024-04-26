using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetAllAkumalators;

public class GetAllAkumalatorsMapper : Profile
{
    public GetAllAkumalatorsMapper()
    {
        CreateMap<Akumalator, GetAllAkumalatorsResponse>();
    }
}
