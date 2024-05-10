using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.DeleteObjectClassTypes;

public sealed record DeleteObjectClassTypesRequest : IRequest<ApiResponse>
{
    public List<int> ObjectClassTypeIds { get; set; }
}
