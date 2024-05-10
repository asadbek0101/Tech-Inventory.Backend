using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassesList;

public sealed record GetObjectClassesListRequest : IRequest<ApiResponse>
{
    public int ObjectClassTypeId { get; set; }
}
