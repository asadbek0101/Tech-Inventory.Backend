using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.AttechmentFeature.UpdateAttechment;

public sealed record UpdateAttechmentRequest : IRequest<ApiResponse>
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
