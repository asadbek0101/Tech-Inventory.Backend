using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StabilizerFeature.GetOneStabilizer;

public class GetOneStabilizerMapper : Profile
{
    public GetOneStabilizerMapper()
    {
        CreateMap<Stabilizer, GetOneStabilizerResponse>();
    }
}
