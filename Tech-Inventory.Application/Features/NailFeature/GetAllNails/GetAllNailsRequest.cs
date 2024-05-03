using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.NailFeature.GetAllNails;

public sealed record GetAllNailsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
