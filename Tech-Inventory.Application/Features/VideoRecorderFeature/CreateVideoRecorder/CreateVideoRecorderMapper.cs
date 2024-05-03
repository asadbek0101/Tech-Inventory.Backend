using AutoMapper;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.CreateVideoRecorder;

public class CreateVideoRecorderMapper : Profile
{
    public CreateVideoRecorderMapper()
    {
        CreateMap<CreateVideoRecorderRequest, VideoRecorder>();
    }
}
