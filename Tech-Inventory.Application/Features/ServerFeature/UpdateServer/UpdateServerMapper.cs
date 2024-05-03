using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ServerFeature.UpdateServer;

public class UpdateServerMapper : Profile
{
    public UpdateServerMapper()
    {
        CreateMap<UpdateServerRequest, Server>();
    }
}
