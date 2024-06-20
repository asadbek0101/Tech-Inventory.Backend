using MediatR;
using Microsoft.AspNetCore.Http;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttachmentFeature.UpdateAttachment;
public sealed record UpdateAttachmentRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string? OriginalFileName { get; set; }
    public string? FileSize { get; set; }
    public IFormFile? File { get; set; }
}
