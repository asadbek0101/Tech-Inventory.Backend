using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.GetOneMountingBox;

public sealed record GetOneMountingBoxRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
