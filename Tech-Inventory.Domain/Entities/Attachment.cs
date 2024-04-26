namespace Tech_Inventory.Domain.Entities;

public class Attachment : BaseEntity
{
    public int ObyektId { get; set; }
    public string Path { get; set; }
    public string OriginalFileName { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string FileSize { get; set; }
    public FileTypes fileType { get; set; }
    public Obyekt Obyekt { get; set; }
}

public enum FileTypes
{
    LTV = 1,
    LSS = 2,
    LETUS = 3,
    LKV = 4,
    KVJR = 5,
}
