namespace Tech_Inventory.Application.Features.ServerFeature.GetOneServer;

public sealed record GetOneServerResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Ip { get; set; }
    public string? Info { get; set; }
}
