using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SocketFeature.GetAllSockets;

public class GetAllSocketsMapper : Profile
{
    public GetAllSocketsMapper()
    {
        CreateMap<Socket, GetAllSocketsResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
