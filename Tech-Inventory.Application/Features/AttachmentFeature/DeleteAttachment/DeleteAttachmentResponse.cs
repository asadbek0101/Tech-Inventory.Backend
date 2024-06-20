namespace Tech_Inventory.Application.Features.AttachmentFeature.DeleteAttachment;

public sealed record DeleteAttachmentResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
