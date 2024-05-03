using AutoMapper;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.GetOneUser;

public class GetOneUserMapper : Profile
{
    public GetOneUserMapper()
    {
        CreateMap<ApplicationUser, GetOneUserResponse>()
            .ForMember(x => x.Region, otp => otp.MapFrom(x => x.Region.Name));
    }
}
