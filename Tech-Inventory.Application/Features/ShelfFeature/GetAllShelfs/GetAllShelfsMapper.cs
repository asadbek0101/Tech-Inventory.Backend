using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetAllShelfs;

public class GetAllShelfsMapper : Profile
{
    public GetAllShelfsMapper()
    {
        CreateMap<Shelf, GetAllShelfsResponse>();
    }
}
