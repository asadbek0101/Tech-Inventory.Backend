using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NailFeature.GetOneNail;

public class GetOneNailMapper : Profile
{
    public GetOneNailMapper()
    {
        CreateMap<Nail, GetOneNailResponse>();
    }
}
