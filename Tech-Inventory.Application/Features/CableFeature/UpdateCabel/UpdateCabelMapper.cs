using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CableFeature.UpdateCabel;

public class UpdateCabelMapper : Profile
{
    public UpdateCabelMapper()
    {
        CreateMap<UpdateCabelRequest, Cabel>();
    }
}
