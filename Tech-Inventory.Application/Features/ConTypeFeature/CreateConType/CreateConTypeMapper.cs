using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConTypeFeature.CreateConType;

public class CreateConTypeMapper : Profile
{
    public CreateConTypeMapper()
    {
        CreateMap<CreateConTypeRequest, FTTX>();
        CreateMap<CreateConTypeRequest, GPON>();
        CreateMap<CreateConTypeRequest, GSM>();
    }
}
