using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassFeature;

public class ObjectClassMapper : Profile
{
    public ObjectClassMapper()
    {
        {
            CreateMap<ObjectClass, GetObjectClassResponse>();
            CreateMap<ObjectClassType, GetObjectClassResponse>();
        }
    }
}
