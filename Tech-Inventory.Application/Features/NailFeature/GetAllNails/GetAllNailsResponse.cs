namespace Tech_Inventory.Application.Features.NailFeature.GetAllNails;

public sealed record GetAllNailsResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Weight { get; set; }
    public string? Info { get; set; }
}
