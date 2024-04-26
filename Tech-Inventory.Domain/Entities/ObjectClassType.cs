namespace Tech_Inventory.Domain.Entities;

public class ObjectClassType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ObjectClass> ObjectClasses { get; set; }
    public List<Obyekt> Obyekts { get; set; }
}
