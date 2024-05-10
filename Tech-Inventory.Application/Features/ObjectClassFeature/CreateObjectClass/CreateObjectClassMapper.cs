using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.CreateObjectClass;

public class CreateObjectClassMapper : Profile
{
    public CreateObjectClassMapper()
    {
        CreateMap<CreateObjectClassRequest, ObjectClass>();
    }
}
