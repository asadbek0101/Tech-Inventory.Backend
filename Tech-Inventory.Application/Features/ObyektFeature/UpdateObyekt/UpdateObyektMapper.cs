using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.UpdateObyekt;

public class UpdateObyektMapper : Profile
{
    public UpdateObyektMapper()
    {
        CreateMap<UpdateObyektRequest, Obyekt>();
    }
}
