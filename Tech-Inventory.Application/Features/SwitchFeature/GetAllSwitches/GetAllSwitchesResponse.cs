namespace Tech_Inventory.Application.Features.SwitchFeature.GetAllSwitches;

public sealed record GetAllSwitchesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
}
