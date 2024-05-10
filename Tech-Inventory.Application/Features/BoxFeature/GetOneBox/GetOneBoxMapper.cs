using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BoxFeature.GetOneBox;

public class GetOneBoxMapper : Profile
{
    public GetOneBoxMapper()
    {
        CreateMap<Box, GetOneBoxResponse>()
            .ForMember(x => x.Type, otp => otp.MapFrom(x => x.Model.Name));
    }
}
