using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ServerFeature.GetOneServer;

public class GetOneServerMapper : Profile
{
    public GetOneServerMapper()
    {
        CreateMap<Server, GetOneServerResponse>();
    }
}
