using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StanchionFeature.CreateStanchion;

public class CreateStanchionMapper : Profile
{
    public CreateStanchionMapper()
    {
        CreateMap<CreateStanchionRequest, Stanchion>();
    }
}
