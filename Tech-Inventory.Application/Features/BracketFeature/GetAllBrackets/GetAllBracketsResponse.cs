using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.GetAllBrackets;

public sealed record GetAllBracketsResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
    public BracketTypes BracketType { get; set; }
}
