using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.CreateSvetafor;

public class CreateSvetaforMapper : Profile
{
    public CreateSvetaforMapper()
    {
        CreateMap<CreateSvetaforRequest, SvetoforDetector>();
    }
}
