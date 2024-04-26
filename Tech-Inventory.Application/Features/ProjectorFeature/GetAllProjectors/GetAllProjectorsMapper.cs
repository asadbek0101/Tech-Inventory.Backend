using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectorFeature.GetAllProjectors;

public class GetAllProjectorsMapper : Profile
{
    public GetAllProjectorsMapper()
    {
        CreateMap<Projector, GetAllProjectorsResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
