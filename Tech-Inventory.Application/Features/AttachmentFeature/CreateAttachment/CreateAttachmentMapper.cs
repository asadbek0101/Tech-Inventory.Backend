using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttachmentFeature.CreateAttachment;

public class CreateAttachmentMapper : Profile
{
    public CreateAttachmentMapper()
    {
        CreateMap<CreateAttachmentRequest, Attachment>();
    }
}
