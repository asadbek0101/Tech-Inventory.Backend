using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CounterFeature.UpdateCounter;

public class UpdateCounterMapper : Profile
{
    public UpdateCounterMapper()
    {
        CreateMap<UpdateCounterRequest, Counter>();
    }
}
