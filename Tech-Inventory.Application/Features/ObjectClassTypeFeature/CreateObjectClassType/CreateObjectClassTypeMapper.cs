using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.CreateObjectClassType;

public class CreateObjectClassTypeMapper : Profile
{
    public CreateObjectClassTypeMapper()
    {
        CreateMap<CreateObjectClassTypeRequest, ObjectClassType>();
    }
}
