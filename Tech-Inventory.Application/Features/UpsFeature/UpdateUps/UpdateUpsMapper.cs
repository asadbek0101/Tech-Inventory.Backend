using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.UpsFeature.UpdateUps;

public class UpdateUpsMapper : Profile
{
    public UpdateUpsMapper()
    {
        CreateMap<UpdateUpsRequest, Ups>();
    }
}
