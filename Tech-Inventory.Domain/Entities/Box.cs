namespace Tech_Inventory.Domain.Entities;

public class Box : BaseEntity
{
    public int ObyektId { get; set; }
    public int TypeId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
    public Model Model { get; set; }
    public Obyekt Obyekt { get; set; }
}
