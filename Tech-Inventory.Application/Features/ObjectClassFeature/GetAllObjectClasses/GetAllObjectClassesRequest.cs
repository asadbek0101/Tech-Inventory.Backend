using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetAllObjectClasses;

public sealed record GetAllObjectClassesRequest : IRequest<ApiResponse>
{
    public int ObjectClassTypeId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 100;
}
