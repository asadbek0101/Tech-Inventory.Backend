namespace Tech_Inventory.Domain.Entities;

public class Region : BaseEntity
{
    public string Name { get; set; }
    public string Info { get; set; }
    public List<District> Districts { get; set; }
    public List<Obyekt> Obyekts { get; set; }
}
