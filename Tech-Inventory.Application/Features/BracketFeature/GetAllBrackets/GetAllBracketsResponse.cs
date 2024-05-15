using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.GetAllBrackets;

public sealed record GetAllBracketsResponse : BaseResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
