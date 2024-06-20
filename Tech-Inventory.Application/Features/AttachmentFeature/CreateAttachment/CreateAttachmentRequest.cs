using MediatR;
using Microsoft.AspNetCore.Http;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttachmentFeature.CreateAttachment;

public sealed record CreateAttachmentRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string? OriginalFileName { get; set; }
    public string? FileSize { get; set; }
    public IFormFile File { get; set; } 
}
