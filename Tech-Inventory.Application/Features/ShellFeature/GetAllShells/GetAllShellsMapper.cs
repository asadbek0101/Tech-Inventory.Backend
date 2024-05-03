using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.GetAllShells;

public class GetAllShellsMapper : Profile
{
    public GetAllShellsMapper()
    {
        CreateMap<Shell, GetAllShellsResponse>();
    }
}
