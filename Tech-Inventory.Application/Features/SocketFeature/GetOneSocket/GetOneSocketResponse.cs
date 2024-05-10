namespace Tech_Inventory.Application.Features.SocketFeature.GetOneSocket;

public sealed record GetOneSocketResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Count { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
