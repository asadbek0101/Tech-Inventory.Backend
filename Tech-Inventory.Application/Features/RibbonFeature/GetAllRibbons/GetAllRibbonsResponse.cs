namespace Tech_Inventory.Application.Features.RibbonFeature.GetAllRibbons;

public sealed record GetAllRibbonsResponse
{
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
