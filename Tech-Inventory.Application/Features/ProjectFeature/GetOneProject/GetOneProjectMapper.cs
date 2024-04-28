using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetOneProject;

public class GetOneProjectMapper : Profile
{
    public GetOneProjectMapper()
    {
        CreateMap<Project, GetOneProjectResponse>();
    }
}
