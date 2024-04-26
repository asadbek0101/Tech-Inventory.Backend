using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.CreateAkumalator;

public class CreateAkumalatorMapper : Profile
{
    public CreateAkumalatorMapper()
    {
        CreateMap<CreateAkumalatorRequest, Akumalator>();
    }
}
