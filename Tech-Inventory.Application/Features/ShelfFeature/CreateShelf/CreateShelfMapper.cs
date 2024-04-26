using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.CreateShelf;

public class CreateShelfMapper : Profile
{
    public CreateShelfMapper()
    {
        CreateMap<CreateShelfRequest, Shelf>();
    }
}
