using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttechmentFeature.CreateAttechment;

public class CreateAttechmentMapper : Profile
{
    public CreateAttechmentMapper()
    {
        CreateMap<CreateAttechmentRequest, Attachment>();
    }
}
