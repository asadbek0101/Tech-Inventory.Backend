using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.UpdateNumberOfOrder;

public class UpdateNumberOfOrderMapper : Profile
{
    public UpdateNumberOfOrderMapper()
    {
        CreateMap<UpdateNumberOfOrderRequest, NumberOfOrder>();
    }
}
