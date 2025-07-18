using AutoMapper;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.GetUsersList;

public class GetUsersListMapper : Profile
{
    public GetUsersListMapper()
    {
        CreateMap<ApplicationUser, GetUsersListResponse>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName + " " + x.MiddleName));  
    }
}
