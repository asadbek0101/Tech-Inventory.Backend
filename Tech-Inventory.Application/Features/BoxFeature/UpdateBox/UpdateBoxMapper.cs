using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BoxFeature.UpdateBox;

public class UpdateBoxMapper : Profile
{
    public UpdateBoxMapper()
    {
        CreateMap<UpdateBoxRequest, Box>();
    }
}
