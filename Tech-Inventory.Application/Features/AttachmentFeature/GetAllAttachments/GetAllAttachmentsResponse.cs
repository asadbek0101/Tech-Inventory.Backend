namespace Tech_Inventory.Application.Features.AttachmentFeature.GetAllAttachments;

public sealed record GetAllAttachmentsResponse
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string OriginalFileName { get; set; }
}
