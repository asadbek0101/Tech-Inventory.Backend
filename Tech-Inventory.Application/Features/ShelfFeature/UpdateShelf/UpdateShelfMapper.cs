using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.UpdateShelf;

public class UpdateShelfMapper : Profile
{
    public UpdateShelfMapper()
    {
        CreateMap<UpdateShelfRequest, Shelf>();
    }
}
