using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetProjectsList;

public class GetProjectsListMapper : Profile
{
    public GetProjectsListMapper()
    {
        CreateMap<Project, GetProjectsListResponse>();
    }
}
