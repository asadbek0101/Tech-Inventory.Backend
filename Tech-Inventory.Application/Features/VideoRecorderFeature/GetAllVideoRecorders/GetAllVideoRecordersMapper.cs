using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.GetAllVideoRecorders;

public class GetAllVideoRecordersMapper : Profile
{
    public GetAllVideoRecordersMapper()
    {
        CreateMap<VideoRecorder, GetAllVideoRecordersResponse>()
            .ForMember(x=>x.Model, otp => otp.MapFrom(x => x.Model.Name));
    }
}
