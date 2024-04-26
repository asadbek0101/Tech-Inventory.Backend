using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.CreateModel;

public class CreateModelMapper : Profile
{
    public CreateModelMapper()
    {
        CreateMap<CreateModelRequest, Model>();
    }
}
