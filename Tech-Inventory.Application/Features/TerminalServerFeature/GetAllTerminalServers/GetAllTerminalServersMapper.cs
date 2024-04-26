using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.GetAllTerminalServers;

public class GetAllTerminalServersMapper : Profile
{
    public GetAllTerminalServersMapper()
    {
        CreateMap<TerminalServer, GetAllTerminalServersResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
