using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SocketFeature.CreateSocket;

public class CreateSocketMapper : Profile
{
    public CreateSocketMapper()
    {
        CreateMap<CreateSocketRequest, Socket>();
    }
}
