using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetOneShelf;

public class GetOneShelfMapper : Profile
{
    public GetOneShelfMapper()
    {
        CreateMap<Shelf, GetOneShelfResponse>();
    }
}
