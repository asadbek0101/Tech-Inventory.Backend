using AutoMapper;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.GetAllusers;

public class GetAllUsersMapper : Profile
{
    public GetAllUsersMapper()
    {
        CreateMap<ApplicationUser, GetAllUsersResponse>();
    }
}
