using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectorFeature.CreateProjector;

public class CreateProjectorMapper : Profile
{
    public CreateProjectorMapper()
    {
        CreateMap<CreateProjectorRequest, Projector>();
    }
}
