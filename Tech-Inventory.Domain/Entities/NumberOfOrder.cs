namespace Tech_Inventory.Domain.Entities;

public class NumberOfOrder : BaseEntity
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Number {  get; set; }
    public string? Info { get; set; }
    public Project Project { get; set; }
    public List<Obyekt> Obyekts { get; set; }
}
