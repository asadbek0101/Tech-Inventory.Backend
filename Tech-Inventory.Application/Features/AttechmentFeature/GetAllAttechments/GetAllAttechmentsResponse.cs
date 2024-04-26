namespace Tech_Inventory.Application.Features.AttechmentFeature.GetAllAttechments;

public sealed record GetAllAttechmentsResponse
{
    public int Id { get; set; }
    public int ObyektId { get; set; }
    public string Path { get; set; }
    public string OriginalFileName { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string FileSize { get; set; }
    public string Info { get; set; }
}
