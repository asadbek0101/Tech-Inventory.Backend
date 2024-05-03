namespace Tech_Inventory.Domain.Entities;

public class Ribbon : BaseEntity
{
    public int ObyektId { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
}
