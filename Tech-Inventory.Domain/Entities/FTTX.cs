namespace Tech_Inventory.Domain.Entities;

public class FTTX : BaseEntity
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string NumberOfPort { get; set; }
    public Obyekt Obyekt { get; set; }
    public Model Model { get; set; }
}
