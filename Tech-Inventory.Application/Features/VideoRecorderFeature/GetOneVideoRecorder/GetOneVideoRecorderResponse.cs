namespace Tech_Inventory.Application.Features.VideoRecorderFeature.GetOneVideoRecorder;

public sealed record GetOneVideoRecorderResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
}
