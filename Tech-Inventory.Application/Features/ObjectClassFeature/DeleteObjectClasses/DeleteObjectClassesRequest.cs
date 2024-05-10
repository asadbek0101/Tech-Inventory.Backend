using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.DeleteObjectClasses;

public sealed record DeleteObjectClassesRequest : IRequest<ApiResponse>
{
    public List<int> ObjectClassIds { get; set; }
}
