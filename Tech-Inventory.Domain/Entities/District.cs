namespace Tech_Inventory.Domain.Entities;

public class District : BaseEntity
{
    public int RegionId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public Region Region { get; set; }
    public List<Obyekt> Obyekts { get; set; }
    public List<Street> Streets { get; set; }
    public List<NumberOfOrder> NumberOfOrders { get; set; }
}
