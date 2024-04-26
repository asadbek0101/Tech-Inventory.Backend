using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.CreateTerminalServer;

public class CreateTerminalServerMapper : Profile
{
    public CreateTerminalServerMapper()
    {
        CreateMap<CreateTerminalServerRequest, TerminalServer>();
    }
}
