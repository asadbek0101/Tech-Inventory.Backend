using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.CreateObyekt;

public class CreateObyektMapper : Profile
{
    public CreateObyektMapper()
    {
        CreateMap<CreateObyektRequest, Obyekt>();
    }
}
