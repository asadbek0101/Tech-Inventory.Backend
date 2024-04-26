using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttechmentFeature.CreateAttechment;

public sealed record CreateAttechmentRequest : IRequest<ApiResponse>
{
    public int ObyektId { get; set; }
    public string Path { get; set; } = "";
    public string OriginalFileName { get; set; } = "";
    public string FileName { get; set; } = "";
    public string ContentType { get; set; } = "";
    public string FileSize { get; set; } = "";
    public string Info { get; set; } = "";
    public FileTypes type { get; set; } = FileTypes.LTV;
}
