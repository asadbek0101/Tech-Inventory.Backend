using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.GetOneMountingBox;

public class GetOneMountingBoxMapper : Profile
{
    public GetOneMountingBoxMapper()
    {
        CreateMap<MountingBox, GetOneMountingBoxResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
