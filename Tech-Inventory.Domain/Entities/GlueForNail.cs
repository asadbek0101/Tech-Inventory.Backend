namespace Tech_Inventory.Domain.Entities;

public class GlueForNail : BaseEntity
{
    public int ObyektId { get; set; }
    public string CountOfCrate { get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
}
