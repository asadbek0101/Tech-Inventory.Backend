using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttachmentFeature.GetAllAttachments;

public sealed record GetAllAttachmentsRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
}
