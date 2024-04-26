namespace Tech_Inventory.Application.Features.CameraFeature.DeleteCamera;

public sealed record DeleteCameraResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
