using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.UpdateShell;

public class UpdateShellMapper : Profile
{
    public UpdateShellMapper()
    {
        CreateMap<UpdateShellRequest, Shell>();
    }
}
