using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.DeleteVideoRecorder;

public sealed record DeleteVideoRecorderRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
