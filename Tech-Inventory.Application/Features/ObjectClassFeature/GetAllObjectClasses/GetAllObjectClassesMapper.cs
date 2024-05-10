using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetAllObjectClasses;

public class GetAllObjectClassesMapper : Profile
{
    public GetAllObjectClassesMapper()
    {
        CreateMap<ObjectClass, GetAllObjectClassesResponse>();
    }
}
