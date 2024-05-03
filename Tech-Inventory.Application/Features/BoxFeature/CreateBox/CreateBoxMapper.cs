using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BoxFeature.CreateBox;

public class CreateBoxMapper : Profile
{
    public CreateBoxMapper()
    {
        CreateMap<CreateBoxRequest, Box>();
    }
}
