using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetOneShelf;

public class GetOneShelfMapper : Profile
{
    public GetOneShelfMapper()
    {
        CreateMap<Shelf, GetOneShelfResponse>()
            .ForMember(x => x.Brand, opt => opt.MapFrom(x => x.Model.Name));
    }
}
