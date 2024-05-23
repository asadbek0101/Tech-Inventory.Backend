using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Features.FileFeature.RemoveFile;
using Tech_Inventory.Application.Features.FileFeature.UpdateFile;
using Tech_Inventory.Application.Features.FileFeature.UploadFile;

namespace Tech_Inventory.WebApi.Controllers;
public class FilesController : BaseController
{

    [HttpPost("UploadFile")]
    public async Task<ActionResult<string>> UploadFile(IFormFile File, [FromQuery] int Id, [FromQuery] string OriginalFileName)
    {
        return await Mediator.Send(new UploadFilesRequest { File = File, Id = Id, OriginalFileName = OriginalFileName });
    }

    [HttpGet("RemoveFile")]
    public async Task<ActionResult<RemoveFileResponse>> RemoveFile([FromQuery] RemoveFileRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("UpdateFile")]
    public async Task<ActionResult<ApiResponse>> UpdateFile([FromBody] UpdateFileRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("DownloadFile")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {

        var filepath = Path.Combine(Path.GetFullPath(FilesFolderURL.URL), fileName);

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(filepath, out var contenttype))
        {
            contenttype = "application/octet-stream";
        }

        var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
        return File(bytes, contenttype, Path.GetFileName(filepath));

    }
}


