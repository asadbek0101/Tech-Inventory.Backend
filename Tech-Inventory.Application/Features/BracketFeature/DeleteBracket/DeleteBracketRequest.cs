using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.BracketFeature.DeleteBracket;

public sealed record DeleteBracketRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
