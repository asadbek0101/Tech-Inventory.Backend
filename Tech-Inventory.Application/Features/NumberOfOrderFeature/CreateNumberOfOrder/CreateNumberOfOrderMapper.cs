using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.CreateNumberOfOrder;

public class CreateNumberOfOrderMapper : Profile
{
    public CreateNumberOfOrderMapper()
    {
        CreateMap<CreateNumberOfOrderRequest, NumberOfOrder>();
    }
}
