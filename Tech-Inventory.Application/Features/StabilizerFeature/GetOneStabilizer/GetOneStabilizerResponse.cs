namespace Tech_Inventory.Application.Features.StabilizerFeature.GetOneStabilizer;

public sealed record GetOneStabilizerResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string Model { get; set; }
    public string Power { get; set; }
    public string? Info { get; set; }
}
