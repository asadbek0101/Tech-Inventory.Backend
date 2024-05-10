using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetOneObjectClass;

public class GetOneObjectClassMapper : Profile
{
    public GetOneObjectClassMapper()
    {
        CreateMap<ObjectClass, GetOneObjectClassResponse>();
    }
}
