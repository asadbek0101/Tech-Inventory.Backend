using AutoMapper;
using Tech_Inventory.Application.Features.ConTypeFeature.CreateConType;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConTypeFeature.UpdateConType;

public class UpdateConTypeMapper : Profile
{
    public UpdateConTypeMapper()
    {
        CreateMap<UpdateConTypeRequest, FTTX>();
        CreateMap<UpdateConTypeRequest, GPON>();
        CreateMap<UpdateConTypeRequest, GSM>();
    }
}
