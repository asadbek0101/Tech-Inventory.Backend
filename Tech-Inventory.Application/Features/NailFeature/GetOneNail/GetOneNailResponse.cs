namespace Tech_Inventory.Application.Features.NailFeature.GetOneNail;

public sealed record GetOneNailResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Weight { get; set; }
    public string? Info { get; set; }
}
