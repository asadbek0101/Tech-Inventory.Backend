using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.DeleteMountingBox;

public sealed record DeleteMountingBoxRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
