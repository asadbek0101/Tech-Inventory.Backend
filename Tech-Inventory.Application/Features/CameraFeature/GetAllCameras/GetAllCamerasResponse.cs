namespace Tech_Inventory.Application.Features.CameraFeature.GetAllCameras;

public sealed record GetAllCamerasResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string Ip { get; set; }
    public string Status { get; set; }
    public string? Info { get; set; }
}
