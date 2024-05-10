namespace Tech_Inventory.Domain.Entities;

public class ObjectClass : BaseEntity
{
    public int ObjectClassTypeId { get; set; }
    public string Name { get; set; }
    public string? Info { get; set; }
    public ObjectClassType ObjectClassType { get; set; }
    public List<Obyekt> Obyekts { get; set;}
}
