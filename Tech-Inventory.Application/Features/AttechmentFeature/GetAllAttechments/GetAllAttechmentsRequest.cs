using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttechmentFeature.GetAllAttechments;

public sealed record GetAllAttechmentsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int PageCount { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
