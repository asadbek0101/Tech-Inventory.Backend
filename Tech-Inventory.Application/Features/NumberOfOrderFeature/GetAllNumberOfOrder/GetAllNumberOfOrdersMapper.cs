using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetAllNumberOfOrder;

public class GetAllNumberOfOrdersMapper : Profile
{
    public GetAllNumberOfOrdersMapper()
    {
        CreateMap<NumberOfOrder, GetAllNumberOfOrdersResponse>();
    }
}
