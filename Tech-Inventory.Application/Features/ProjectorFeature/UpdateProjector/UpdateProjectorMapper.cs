using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectorFeature.UpdateProjector;

public class UpdateProjectorMapper : Profile
{
    public UpdateProjectorMapper()
    {
        CreateMap<UpdateProjectorRequest, Projector>();
    }
}
