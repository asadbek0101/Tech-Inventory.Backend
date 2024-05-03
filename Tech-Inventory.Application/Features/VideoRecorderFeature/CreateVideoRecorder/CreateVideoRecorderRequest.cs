using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.CreateVideoRecorder;

public sealed record CreateVideoRecorderRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
}
