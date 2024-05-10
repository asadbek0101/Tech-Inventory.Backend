using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RackFeature.GetOneRack;

public sealed record GetOneRackResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string NumberOfFibers { get; set; }
    public string TypeOfAdapter { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public RackTypes RackType { get; set; }
}
