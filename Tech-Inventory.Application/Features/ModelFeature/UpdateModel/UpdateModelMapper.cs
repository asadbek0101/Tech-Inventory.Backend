using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.UpdateModel;

public class UpdateModelMapper : Profile
{
    public UpdateModelMapper()
    {
        CreateMap<UpdateModelRequest, Model>();
    }
}
