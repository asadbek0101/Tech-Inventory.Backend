namespace Tech_Inventory.Domain.Entities;

public class Switch : BaseEntity
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Name { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public SwitchTypes SwitchType { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}

public enum SwitchTypes
{
    SwitchCombo = 1,
    SwitchPoE = 2,
}