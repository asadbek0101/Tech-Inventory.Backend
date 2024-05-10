using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CounterFeature.GetOneCounter;

public class GetOneCounterMapper : Profile
{
    public GetOneCounterMapper()
    {
        CreateMap<Counter, GetOneCounterResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
