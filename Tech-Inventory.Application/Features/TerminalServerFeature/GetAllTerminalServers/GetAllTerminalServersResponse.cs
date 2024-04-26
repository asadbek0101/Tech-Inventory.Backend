namespace Tech_Inventory.Application.Features.TerminalServerFeature.GetAllTerminalServers;

public sealed record GetAllTerminalServersResponse
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
