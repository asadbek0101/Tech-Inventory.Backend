using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.FreezerFeature.UpdateFreezer;

public class UpdateFreezerMapper : Profile
{
    public UpdateFreezerMapper()
    {
        CreateMap<UpdateFreezerRequest, Freezer>();
    }
}
