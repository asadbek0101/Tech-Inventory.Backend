using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Tech_Inventory.Application.Features.AttechmentFeature.CreateAttechment;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.WebApi.Controllers;
public class FilesController : BaseController
{
    private async Task<string> WriteFile(IFormFile file)
    {
        string filename = "";
        try
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            filename = DateTime.Now.Ticks.ToString() + extension;

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filename;

        }
        catch (Exception ex)
        {
        }
        return filename;
    }

    [HttpPost("UploadFile")]
    
    public async Task<IActionResult> UploadFile(IFormFile file, [FromQuery] int Id, [FromQuery] string fileName, [FromQuery] FileTypes type, CancellationToken cancellationtoken)
    {
        try
        {
            var result = await WriteFile(file);
            var isCreatedAttachment = await Mediator.Send(new CreateAttechmentRequest { ObyektId = Id, Path = result, FileName= fileName, type = type, ContentType = file.ContentType, }) ;
            
            if (isCreatedAttachment.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpGet("DownloadFile")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
        
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contenttype, Path.GetFileName(filepath));

    }
}


