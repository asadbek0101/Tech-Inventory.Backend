using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CableFeature.CreateCabel;

public class CreateCabelMapper : Profile
{
    public CreateCabelMapper()
    {
        CreateMap<CreateCabelRequest, Cabel>();
    }
}
