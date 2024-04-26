namespace Tech_Inventory.Domain.Entities;

public class Rack : BaseEntity
{
    public int ObyektId { get; set; }
    public string? Name { get; set; }
    public string NumberOfFibers { get; set; }
    public string TypeOfAdapter { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public RackTypes RackType { get; set; }
    public Obyekt Obyekt { get; set; }
}

public enum RackTypes
{
    ODFOpticRack = 1,
    MiniOpticRack = 2,
}
