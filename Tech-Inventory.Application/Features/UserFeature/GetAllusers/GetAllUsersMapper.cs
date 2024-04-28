using AutoMapper;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.GetAllusers;

public class GetAllUsersMapper : Profile
{
    public GetAllUsersMapper()
    {
        CreateMap<ApplicationUser, GetAllUsersResponse>()
            .ForMember(x=>x.Region, otp => otp.MapFrom(x => x.Region.Name))
            .ForMember(x=>x.District, otp => otp.MapFrom(x => x.District.Name));
    }
}
