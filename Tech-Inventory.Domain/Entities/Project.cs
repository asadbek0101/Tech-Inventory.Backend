namespace Tech_Inventory.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string? Info { get; set; }
    public List<Obyekt> Obyekts { get; set; }
    public List<NumberOfOrder> NumberOfOrders { get; set; }
}
