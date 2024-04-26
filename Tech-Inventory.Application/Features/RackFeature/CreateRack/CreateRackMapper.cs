using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RackFeature.CreateRack;

public class CreateRackMapper : Profile
{
    public CreateRackMapper()
    {
        CreateMap<CreateRackRequest, Rack>();
    }
}
