using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttachmentFeature.GetAllAttachments;

public class GetAllAttachmentsMapper : Profile
{
    public GetAllAttachmentsMapper()
    {
        CreateMap<Attachment, GetAllAttachmentsResponse>();
    }
}
