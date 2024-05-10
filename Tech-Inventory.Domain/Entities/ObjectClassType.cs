namespace Tech_Inventory.Domain.Entities;

public class ObjectClassType : BaseEntity
{
    public string Name { get; set; }
    public string? Info { get; set; }
    public List<ObjectClass> ObjectClasses { get; set; }
    public List<Obyekt> Obyekts { get; set; }
}
