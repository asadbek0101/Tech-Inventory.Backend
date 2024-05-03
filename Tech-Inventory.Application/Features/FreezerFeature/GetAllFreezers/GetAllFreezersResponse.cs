namespace Tech_Inventory.Application.Features.FreezerFeature.GetAllFreezers;

public sealed record GetAllFreezersResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
