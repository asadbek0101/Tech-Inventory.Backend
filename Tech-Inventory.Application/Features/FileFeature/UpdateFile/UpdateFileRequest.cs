using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.FileFeature.UpdateFile;

public sealed record UpdateFileRequest : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string OriginalFileName { get; set; }
}
