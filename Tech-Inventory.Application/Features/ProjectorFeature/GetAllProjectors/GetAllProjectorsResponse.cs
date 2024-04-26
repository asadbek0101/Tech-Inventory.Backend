namespace Tech_Inventory.Application.Features.ProjectorFeature.GetAllProjectors;

public sealed record GetAllProjectorsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
}
