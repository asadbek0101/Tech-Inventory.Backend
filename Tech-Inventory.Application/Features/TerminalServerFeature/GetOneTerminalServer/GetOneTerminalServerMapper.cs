using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.GetOenTerminalServer;

public class GetOneTerminalServerMapper : Profile
{
    public GetOneTerminalServerMapper()
    {
        CreateMap<TerminalServer, GetOneTerminalServerResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
