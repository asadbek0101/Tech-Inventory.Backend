namespace Tech_Inventory.Domain.Entities;

public class Street
{
    public int Id { get; set; }
    public int DistrictId { get; set; }
    public string Name { get; set; }
    public District District { get; set; }
    public List<Obyekt> Obyekts { get; set; }
}
