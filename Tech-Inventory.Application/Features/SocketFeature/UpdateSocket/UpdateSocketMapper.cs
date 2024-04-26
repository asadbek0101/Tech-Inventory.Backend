using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SocketFeature.UpdateSocket;

public class UpdateSocketMapper : Profile
{
    public UpdateSocketMapper()
    {
        CreateMap<UpdateSocketRequest, Socket>();
    }
}
