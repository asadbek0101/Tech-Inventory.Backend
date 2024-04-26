using AutoMapper;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.StabilizerFeature.UpdateStabilizer;

public class UpdateStabilizerMapper : Profile
{
    public UpdateStabilizerMapper()
    {
        CreateMap<UpdateStabilizerRequest, ApiResponse>();
    }
}
