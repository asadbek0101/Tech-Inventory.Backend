using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetModelsList;

public class GetModelsListMapper : Profile
{
    public GetModelsListMapper()
    {
        CreateMap<Model, GetModelsListResponse>();
    }
}
