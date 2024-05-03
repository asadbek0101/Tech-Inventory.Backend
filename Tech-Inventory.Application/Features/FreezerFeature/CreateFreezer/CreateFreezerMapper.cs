using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.FreezerFeature.CreateFreezer;

public class CreateFreezerMapper : Profile
{
    public CreateFreezerMapper()
    {
        CreateMap<CreateFreezerRequest, Freezer>();
    }
}
