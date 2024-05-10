using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassesList;

public class GetObjectClassesListMapper : Profile
{
    public GetObjectClassesListMapper()
    {
        CreateMap<ObjectClass, GetObjectClassesListResponse>();
    }
}
