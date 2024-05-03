using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.UpdateVideoRecorder;

public class UpdateVideoRecorderMapper : Profile
{
    public UpdateVideoRecorderMapper()
    {
        CreateMap<UpdateVideoRecorderRequest, VideoRecorder>();
    }
}
