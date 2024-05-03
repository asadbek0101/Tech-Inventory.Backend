namespace Tech_Inventory.Domain.Entities;

public class Nail : BaseEntity
{
    public int ObyektId { get; set; }
    public string Weight { get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
}
