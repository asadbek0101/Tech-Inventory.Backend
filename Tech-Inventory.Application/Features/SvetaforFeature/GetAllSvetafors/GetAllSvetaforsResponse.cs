namespace Tech_Inventory.Application.Features.SvetaforFeature.GetAllSvetafors;

public sealed record GetAllSvetaforsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
}
