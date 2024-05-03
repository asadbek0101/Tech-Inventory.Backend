namespace Tech_Inventory.Domain.Entities;

public class Server : BaseEntity
{
    public int ObyektId { get; set; }
    public string Ip {  get; set; }
    public string? Info { get; set; }
    public Obyekt Obyekt { get; set; }
}
