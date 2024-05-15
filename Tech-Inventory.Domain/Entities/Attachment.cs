namespace Tech_Inventory.Domain.Entities;

public class Attachment : BaseEntity
{
    public int ObyektId { get; set; }
    public string FileName { get; set; }
    public string OriginalFileName { get; set; }
    public string FileSize { get; set; }
    public Obyekt Obyekt { get; set; }
}

