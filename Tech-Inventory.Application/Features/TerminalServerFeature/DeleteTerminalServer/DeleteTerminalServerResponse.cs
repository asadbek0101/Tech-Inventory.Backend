namespace Tech_Inventory.Application.Features.TerminalServerFeature.DeleteTerminalServer;

public sealed record DeleteTerminalServerResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
