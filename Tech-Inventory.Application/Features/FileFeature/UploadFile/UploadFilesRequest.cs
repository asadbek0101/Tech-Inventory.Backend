using MediatR;
using Microsoft.AspNetCore.Http;

namespace Tech_Inventory.Application.Features.FileFeature.UploadFile;

public sealed record UploadFilesRequest : IRequest<string>
{
    public int Id { get; set; }
    public IFormFile File { get; set; }
}
