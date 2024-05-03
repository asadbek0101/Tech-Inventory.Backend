using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.CreateShell;

public class CreateShellMapper : Profile
{
    public CreateShellMapper()
    {
        CreateMap<CreateShellRequest, Shell>();
    }
}
