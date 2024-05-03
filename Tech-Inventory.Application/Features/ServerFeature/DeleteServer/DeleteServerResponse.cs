namespace Tech_Inventory.Application.Features.ServerFeature.DeleteServer;

public sealed record DeleteServerResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
