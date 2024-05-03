namespace Tech_Inventory.Application.Features.RibbonFeature.GetOneRibbon;

public sealed record GetOneRibbonResponse
{
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
