namespace Tech_Inventory.Application.Features.TerminalServerFeature.GetOenTerminalServer;

public sealed record GetOneTerminalServerResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
