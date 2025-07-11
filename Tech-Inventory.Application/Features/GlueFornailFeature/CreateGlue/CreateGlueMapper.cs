using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.CreateGlue;

public class CreateGlueMapper : Profile
{
    public CreateGlueMapper()
    {
        CreateMap<CreateGlueRequest, GlueForNail>();
    }
}
