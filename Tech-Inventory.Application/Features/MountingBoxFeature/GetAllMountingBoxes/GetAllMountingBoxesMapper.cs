using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.GetAllMountingBoxes;

public class GetAllMountingBoxesMapper : Profile
{
    public GetAllMountingBoxesMapper()
    {
        CreateMap<MountingBox, GetAllMountingBoxesResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
