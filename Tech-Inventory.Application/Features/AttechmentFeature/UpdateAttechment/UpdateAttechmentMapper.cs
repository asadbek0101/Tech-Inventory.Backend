using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttechmentFeature.UpdateAttechment;

public class UpdateAttechmentMapper : Profile
{
    public UpdateAttechmentMapper()
    {
        CreateMap<UpdateAttechmentRequest, Attachment>();
    }
}
