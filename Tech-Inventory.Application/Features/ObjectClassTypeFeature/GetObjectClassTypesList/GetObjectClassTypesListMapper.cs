using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetObjectClassTypesList;

public class GetObjectClassTypesListMapper : Profile
{
    public GetObjectClassTypesListMapper()
    {
        CreateMap<ObjectClassType, GetObjectClassTypesListResponse>();
    }
}
