using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.UpsFeature.CreateUps;

public class CreateUpsMapper : Profile
{
    public CreateUpsMapper()
    {
        CreateMap<CreateUpsRequest, Ups>();
    }
}
