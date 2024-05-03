using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NailFeature.UpdateNail;

public class UpdateNailMapper : Profile
{
    public UpdateNailMapper()
    {
        CreateMap<UpdateNailRequest, Nail>();
    }
}
