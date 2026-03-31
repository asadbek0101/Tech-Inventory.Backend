using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetAllNumberOfOrder;

public class GetAllNumberOfOrdersMapper : Profile
{
    public GetAllNumberOfOrdersMapper()
    {
        CreateMap<NumberOfOrder, GetAllNumberOfOrdersResponse>()
            .ForMember(x=>x.Region, otp =>otp.MapFrom(x=>x.Region.Name))
            .ForMember(x=>x.District, otp =>otp.MapFrom(x=>x.District.Name));
    }
}
