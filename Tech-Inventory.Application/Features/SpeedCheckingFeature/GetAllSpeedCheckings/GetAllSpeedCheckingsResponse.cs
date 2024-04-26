namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.GetAllSpeedCheckings;

public sealed record GetAllSpeedCheckingsResponse
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string? Info { get; set; }
}
