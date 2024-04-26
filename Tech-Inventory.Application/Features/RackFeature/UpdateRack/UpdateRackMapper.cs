using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RackFeature.UpdateRack;

public class UpdateRackMapper : Profile
{
    public UpdateRackMapper()
    {
        CreateMap<UpdateRackRequest, Rack>();
    }
}
