using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.GetOneShell;

public class GetOneShellMapper : Profile
{
    public GetOneShellMapper()
    {
        CreateMap<Shell, GetOneShellResponse>();
    }
}
