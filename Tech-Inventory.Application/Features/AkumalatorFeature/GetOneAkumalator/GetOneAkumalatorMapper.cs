using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetOneAkumalator;

public class GetOneAkumalatorMapper : Profile
{
    public GetOneAkumalatorMapper()
    {
        CreateMap<Akumalator, GetOneAkumalatorResponse>();
    }
}
