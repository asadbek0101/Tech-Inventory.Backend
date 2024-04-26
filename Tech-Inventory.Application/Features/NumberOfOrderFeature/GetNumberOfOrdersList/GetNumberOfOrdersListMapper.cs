using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetNumberOfOrdersList;

public class GetNumberOfOrdersListMapper : Profile
{
    public GetNumberOfOrdersListMapper()
    {
        CreateMap<NumberOfOrder, GetNumberOfOrdersListResponse>();
    }
}
