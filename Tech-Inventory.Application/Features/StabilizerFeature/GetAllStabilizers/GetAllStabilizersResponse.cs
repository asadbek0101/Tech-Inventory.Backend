namespace Tech_Inventory.Application.Features.StabilizerFeature.GetAllStabilizers;

public sealed record GetAllStabilizersResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Power { get; set; }
    public string? Info { get; set; }
}
