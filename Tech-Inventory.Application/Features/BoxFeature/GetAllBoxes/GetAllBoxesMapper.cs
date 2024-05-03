using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BoxFeature.GetAllBoxes;

public class GetAllBoxesMapper : Profile
{
    public GetAllBoxesMapper()
    {
        CreateMap<Box, GetAllBoxesResponse>()
            .ForMember(x=>x.Type, otp => otp.MapFrom(x=>x.Model.Name));
    }
}
