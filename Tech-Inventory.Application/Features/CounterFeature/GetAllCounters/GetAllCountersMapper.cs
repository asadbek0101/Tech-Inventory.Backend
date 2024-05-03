using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CounterFeature.GetAllCounters;

public class GetAllCountersMapper : Profile
{
    public GetAllCountersMapper()
    {
        CreateMap<Counter, GetAllCountersResponse>()
            .ForMember(x => x.Model, otp=>otp.MapFrom(x => x.Model.Name));
    }
}
