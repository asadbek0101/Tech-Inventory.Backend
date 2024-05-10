using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.GetOneVideoRecorder;

public class GetOneVideoRecorderMapper : Profile
{
    public GetOneVideoRecorderMapper()
    {
        CreateMap<VideoRecorder, GetOneVideoRecorderResponse>()
            .ForMember(x => x.Model, otp => otp.MapFrom(x => x.Model.Name)); 
    }
}
