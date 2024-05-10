namespace Tech_Inventory.Application.Features.StanchionFeature.GetOneStanchion;

public sealed record GetOneStanchionResponse
{
    public int Id { get; set; }
    public int StanchionTypeId { get; set; }
    public string StanchionType { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
