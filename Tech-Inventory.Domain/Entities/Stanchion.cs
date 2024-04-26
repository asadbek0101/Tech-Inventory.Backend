namespace Tech_Inventory.Domain.Entities;

public class Stanchion : BaseEntity
{
    public int ObyektId { get; set; }
    public int StanchionTypeId { get; set; }
    public string? Name { get; set; }
    public string Count { get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}
