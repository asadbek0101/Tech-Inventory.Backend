using AutoMapper;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.RoleFeature.GetRolesList;

public class GetRolesListMapper : Profile
{
    public GetRolesListMapper()
    {
        CreateMap<ApplicationRole, GetRolesListResponse>()
            .ForMember(x => x.Name, otp => otp.MapFrom(x => x.RoleLabel));
    }
}
