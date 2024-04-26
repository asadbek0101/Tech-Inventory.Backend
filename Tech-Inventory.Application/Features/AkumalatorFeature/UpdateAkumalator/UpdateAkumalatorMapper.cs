using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.UpdateAkumalator;

public class UpdateAkumalatorMapper : Profile
{
    public UpdateAkumalatorMapper()
    {
        CreateMap<UpdateAkumalatorRequest, Akumalator>();
    }
}
