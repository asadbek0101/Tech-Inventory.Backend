namespace Tech_Inventory.Domain.Entities;

public class Camera : BaseEntity
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Name { get; set; }
    public string SerialNumber { get; set; }
    public string Ip { get; set; }
    public string Status { get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}
