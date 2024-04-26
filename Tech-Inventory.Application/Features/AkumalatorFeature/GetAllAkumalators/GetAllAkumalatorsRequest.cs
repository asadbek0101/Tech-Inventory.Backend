using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetAllAkumalators;

public sealed record GetAllAkumalatorsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int PageCount { get; set; } = 1;
    public int PageSize { get; set; } = 20; 
}
