using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CableFeature.GetAllCabels;

public sealed record GetAllCabelsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int PageCount { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public CabelTypes cabelType { get; set; } = CabelTypes.UTPable;
}
