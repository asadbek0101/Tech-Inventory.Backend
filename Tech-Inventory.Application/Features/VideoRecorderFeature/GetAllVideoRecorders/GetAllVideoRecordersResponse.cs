namespace Tech_Inventory.Application.Features.VideoRecorderFeature.GetAllVideoRecorders;

public sealed record GetAllVideoRecordersResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string? Info { get; set; }
}
