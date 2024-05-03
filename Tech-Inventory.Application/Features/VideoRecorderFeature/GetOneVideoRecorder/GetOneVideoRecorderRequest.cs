using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.GetOneVideoRecorder;

public sealed record GetOneVideoRecorderRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
