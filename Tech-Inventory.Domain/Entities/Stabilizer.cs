namespace Tech_Inventory.Domain.Entities;

public class Stabilizer : BaseEntity
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Name { get; set; }
    public string Power { get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}
