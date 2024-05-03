namespace Tech_Inventory.Application.Features.FreezerFeature.GetOneFreezer;

public sealed record GetOneFreezerResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
