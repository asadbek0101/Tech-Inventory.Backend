namespace Tech_Inventory.Domain.Entities;

public class Freezer : BaseEntity
{
    public int ObyektId { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
}
