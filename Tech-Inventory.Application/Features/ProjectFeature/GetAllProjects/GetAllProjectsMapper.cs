using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetAllProjects;

public class GetAllProjectsMapper : Profile
{
    public GetAllProjectsMapper()
    {
        CreateMap<Project, GetAllProjectsResponse>();
    }
}
