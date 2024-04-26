using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttechmentFeature.GetAllAttechments;

public class GetAllAttechmentsMapper : Profile
{
    public GetAllAttechmentsMapper()
    {
        CreateMap<Attachment, GetAllAttechmentsResponse>();
    }
}
