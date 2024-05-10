using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetOneObjectClassType;

public class GetOneObjectClassTypeMapper : Profile
{
    public GetOneObjectClassTypeMapper()
    {
        CreateMap<ObjectClassType, GetOneObjectClassTypeResponse>();
    }
}
