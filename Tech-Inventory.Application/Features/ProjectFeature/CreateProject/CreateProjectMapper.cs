using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectFeature.CreateProject;

public class CreateProjectMapper : Profile
{
    public CreateProjectMapper()
    {
        CreateMap<CreateProjectRequest, Project>();
    }
}
