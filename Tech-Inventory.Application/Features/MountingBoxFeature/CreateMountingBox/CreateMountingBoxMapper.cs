using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.CreateMountingBox;

public class CreateMountingBoxMapper : Profile
{
    public CreateMountingBoxMapper()
    {
        CreateMap<CreateMountingBoxRequest, MountingBox>();
    }
}
