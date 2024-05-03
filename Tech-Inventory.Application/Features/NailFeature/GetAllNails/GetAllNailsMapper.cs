using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NailFeature.GetAllNails;

public class GetAllNailsMapper : Profile
{
    public GetAllNailsMapper()
    {
        CreateMap<Nail, GetAllNailsResponse>();
    }
}
