namespace Tech_Inventory.Domain.Entities;

public class SvetoforDetector : BaseEntity
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Name { get; set; }
    public string CountOfPorts { get; set; }
    public string? Info { get; set; }
    public SvetaforTypes SvetaforType { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}

public enum SvetaforTypes
{
    SvetaforDetector = 1,
    SvetaforDetectorForCamera = 2,
}
