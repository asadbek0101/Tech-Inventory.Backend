namespace Tech_Inventory.Application.Features.ConnectorFeature.GetAllConnectors;

public sealed record GetAllConnectorsResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
