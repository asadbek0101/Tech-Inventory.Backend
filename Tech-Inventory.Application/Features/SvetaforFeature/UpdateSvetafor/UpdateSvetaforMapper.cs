using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.UpdateSvetafor;

public class UpdateSvetaforMapper : Profile
{
    public UpdateSvetaforMapper()
    {
        CreateMap<UpdateSvetaforRequest, SvetoforDetector>();
    }
}
