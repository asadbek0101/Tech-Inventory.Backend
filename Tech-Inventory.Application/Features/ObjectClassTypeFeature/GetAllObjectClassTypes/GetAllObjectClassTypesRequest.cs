using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetAllObjectClassTypes;

public sealed record GetAllObjectClassTypesRequest : IRequest<ApiResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public string? SearchValue { get; set; }
}
