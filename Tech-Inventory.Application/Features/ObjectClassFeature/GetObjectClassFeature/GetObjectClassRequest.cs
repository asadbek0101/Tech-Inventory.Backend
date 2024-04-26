using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassFeature;

public sealed record GetObjectClassRequest : IRequest<ApiResponse>
{
    public int ObjectClassTypeId { get; set; } = 0;
}
