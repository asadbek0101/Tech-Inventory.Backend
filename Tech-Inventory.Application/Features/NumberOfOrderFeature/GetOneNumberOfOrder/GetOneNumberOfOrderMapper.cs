using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetOneNumberOfOrder;

public class GetOneNumberOfOrderMapper : Profile
{
    public GetOneNumberOfOrderMapper()
    {
        CreateMap<NumberOfOrder, GetOneNumberOfOrderResponse>();
    }
}
