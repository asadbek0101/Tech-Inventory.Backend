using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttachmentFeature.DeleteAttachment;

public sealed record DeleteAttachmentRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
}
