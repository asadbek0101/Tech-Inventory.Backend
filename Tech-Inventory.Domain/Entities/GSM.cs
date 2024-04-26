namespace Tech_Inventory.Domain.Entities;

public class GSM : BaseEntity
{
    public int ObyektId { get; set; }
    public string PhoneNumber { get; set; }
    public Obyekt Obyekt { get; set; }
}
