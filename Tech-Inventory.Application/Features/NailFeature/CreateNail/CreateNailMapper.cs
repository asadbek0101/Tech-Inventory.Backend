using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NailFeature.CreateNail;

public class CreateNailMapper : Profile
{
    public CreateNailMapper()
    {
        CreateMap<CreateNailRequest, Nail>();
    }
}
