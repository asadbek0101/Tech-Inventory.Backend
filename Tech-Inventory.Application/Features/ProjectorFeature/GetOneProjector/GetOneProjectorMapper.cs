using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectorFeature.GetOneProjector;

public class GetOneProjectorMapper : Profile
{
    public GetOneProjectorMapper()
    {
        CreateMap<Projector, GetOneProjectorResponse>();
    }
}
