namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetOneAkumalator;

public sealed record GetOneAkumalatorResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Power { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
