namespace Tech_Inventory.Domain.Entities;

public class Cabel : BaseEntity
{
    public int ObyektId { get; set; }
    public int CabelTypeId { get; set; }
    public int ModelId { get; set; }
    public string? Name { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
    public CabelTypes CabelType { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}

public enum CabelTypes {
    ElectricCable = 1,
    UTPable = 2
}

