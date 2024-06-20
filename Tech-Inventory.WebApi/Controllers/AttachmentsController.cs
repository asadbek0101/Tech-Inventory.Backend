using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.AttachmentFeature.CreateAttachment;
using Tech_Inventory.Application.Features.AttachmentFeature.DeleteAttachment;
using Tech_Inventory.Application.Features.AttachmentFeature.GetAllAttachments;
using Tech_Inventory.Application.Features.AttachmentFeature.UpdateAttachment;

namespace Tech_Inventory.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttachmentsController : BaseController
{

    private readonly IMinioService _minioService;

    public AttachmentsController(IMinioService minioService)
    {
        _minioService = minioService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ApiResponse>> GetAll([FromQuery] GetAllAttachmentsRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("Download")]
    public async Task<ActionResult> Get(string token)
    {
        var result = await _minioService.GetObject(token);
        return File(result.Bytes, result.ContentType, token);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResponse>> Create(IFormFile File, [FromQuery] int ObjectId, [FromQuery] string OriginalFileName)
    {
        return await Mediator.Send(new CreateAttachmentRequest { File = File, ObyektId = ObjectId, OriginalFileName = OriginalFileName });
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ApiResponse>> Update(IFormFile File, [FromQuery] int Id, [FromQuery] string OriginalFileName)
    {
        return await Mediator.Send(new UpdateAttachmentRequest { File = File, Id = Id, OriginalFileName = OriginalFileName });
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResponse>> Delete([FromQuery] DeleteAttachmentRequest request)
    {
        return await Mediator.Send(request);
    }
}
