using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CounterFeature.CreateCounter;

public class CreateCounterMapper : Profile
{
    public CreateCounterMapper()
    {
        CreateMap<CreateCounterRequest, Counter>();
    }
}
