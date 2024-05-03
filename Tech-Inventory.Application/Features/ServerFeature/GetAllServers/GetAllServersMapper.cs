using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ServerFeature.GetAllServers;

public class GetAllServersMapper : Profile
{
    public GetAllServersMapper()
    {
        CreateMap<Server, GetAllServersResponse>();
    }
}
