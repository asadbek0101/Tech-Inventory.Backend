using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RackFeature.GetOneRack;

public class GetOneRackMapper : Profile
{
    public GetOneRackMapper()
    {
        CreateMap<Rack, GetOneRackResponse>();
    }
}
