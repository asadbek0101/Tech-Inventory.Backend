using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectFeature.UpdateProject;

public class UpdateProjectMapper : Profile
{
    public UpdateProjectMapper()
    {
        CreateMap<UpdateProjectRequest, Project>();
    }
}
