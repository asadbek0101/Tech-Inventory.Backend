using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.CreateSpeedChecking;

public class CreateSpeedCheckingMapper : Profile
{
    public CreateSpeedCheckingMapper()
    {
        CreateMap<CreateSpeedCheckingRequest, SpeedChecking>();
    }
}
