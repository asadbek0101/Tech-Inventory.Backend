using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttechmentFeature.GetOneAttechment;

public class GetOneAttechmentMapper : Profile
{
    public GetOneAttechmentMapper()
    {
        CreateMap<Attachment, GetOneAttechmentResponse>();
    }
}
