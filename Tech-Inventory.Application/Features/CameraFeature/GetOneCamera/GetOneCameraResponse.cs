namespace Tech_Inventory.Application.Features.CameraFeature.GetOneCamera;

public sealed record GetOneCameraResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int CameraTypeId { get; set; }
    public int CameraBrandId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string Ip { get; set; }
    public string Status { get; set; }
}
