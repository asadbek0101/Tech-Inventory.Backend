using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.UpdateVideoRecorder;

public sealed record UpdateVideoRecorderRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
}
