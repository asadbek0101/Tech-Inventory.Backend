namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.GetOneSpeedChecking;

public sealed record GetOneSpeedCheckingResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string? Info { get; set; }
}
