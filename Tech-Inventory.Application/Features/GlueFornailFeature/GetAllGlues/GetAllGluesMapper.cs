using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.GetAllGlues;

public class GetAllGluesMapper : Profile
{
    public GetAllGluesMapper()
    {
        CreateMap<GlueForNail, GetAllGluesResponse>();
    }
}
