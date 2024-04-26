namespace Tech_Inventory.Domain.Entities;

public class ObjectClass
{
    public int ObjectClassTypeId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public ObjectClassType ObjectClassType { get; set; }
    public List<Obyekt> Obyekts { get; set;}
}
