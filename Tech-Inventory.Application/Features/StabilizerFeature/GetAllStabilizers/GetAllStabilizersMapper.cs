using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StabilizerFeature.GetAllStabilizers;

public class GetAllStabilizersMapper : Profile
{
    public GetAllStabilizersMapper()
    {
        CreateMap<Stabilizer, GetAllStabilizersResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
