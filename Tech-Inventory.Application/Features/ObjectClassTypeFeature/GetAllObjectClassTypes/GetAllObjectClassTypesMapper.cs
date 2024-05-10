using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetAllObjectClassTypes;

public class GetAllObjectClassTypesMapper : Profile
{
    public GetAllObjectClassTypesMapper()
    {
        CreateMap<ObjectClassType, GetAllObjectClassTypesResponse>();
    }
}
