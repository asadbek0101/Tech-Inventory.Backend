using MediatR;

namespace Tech_Inventory.Application.Features.FileFeature.RemoveFile;

public sealed record RemoveFileRequest : IRequest<RemoveFileResponse>
{
    public int Id { get; set; }
    public string FileName { get; set; }
}
