using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.CreateBracket;

public sealed record CreateBracketRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
    public BracketTypes BracketType { get; set; }
}
