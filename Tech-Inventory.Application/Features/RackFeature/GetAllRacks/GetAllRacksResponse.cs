namespace Tech_Inventory.Application.Features.RackFeature.GetAllRacks;

public sealed record GetAllRacksResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NumberOfFibers { get; set; }
    public string TypeOfAdapter { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
}
