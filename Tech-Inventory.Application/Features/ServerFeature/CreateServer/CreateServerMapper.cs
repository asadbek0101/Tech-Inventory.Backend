using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ServerFeature.CreateServer;

public class CreateServerMapper : Profile
{
    public CreateServerMapper()
    {
        CreateMap<CreateServerRequest, Server>();
    }
}
