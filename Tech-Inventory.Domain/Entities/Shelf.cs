namespace Tech_Inventory.Domain.Entities;

public class Shelf : BaseEntity
{
    public int ObyektId { get; set; }
    public int BrandId { get; set; }
    public string? Name { get; set; }
    public string SerialNumber { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
    public ShelfTypes ShelfType { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}

public enum ShelfTypes
{
    CentralTelecommunicationShelf = 1,
    TelecommunicationShelf = 2,
    MainElectronicShelf = 3,
    DistributionShelf = 4,
}
