using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.GetOneBracket;

public sealed record GetOneBracketResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
    public BracketTypes BracketType { get; set; }
}
