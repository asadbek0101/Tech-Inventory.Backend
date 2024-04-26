using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StabilizerFeature.CreateStabilizer;

public class CreateStabilizerMapper : Profile
{
    public CreateStabilizerMapper()
    {
        CreateMap<CreateStabilizerRequest, Stabilizer>();
    }
}
