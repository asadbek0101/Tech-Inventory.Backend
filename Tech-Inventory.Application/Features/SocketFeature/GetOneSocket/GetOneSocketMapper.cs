using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SocketFeature.GetOneSocket;

public class GetOneSocketMapper : Profile
{
    public GetOneSocketMapper()
    {
        CreateMap<Socket, GetOneSocketResponse>();
    }
}
