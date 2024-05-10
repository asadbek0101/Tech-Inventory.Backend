using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.BracketFeature.GetAllBrackets;

public sealed record GetAllBracketsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int PageNumber { get; set; } = 1; 
    public int PageSize { get; set;} = 20;
}
