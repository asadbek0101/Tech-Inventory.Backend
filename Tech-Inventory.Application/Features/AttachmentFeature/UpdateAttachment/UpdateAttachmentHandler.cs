using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AttachmentFeature.UpdateAttachment;

public class UpdateAttachmentHandler : IRequestHandler<UpdateAttachmentRequest, ApiResponse>
{
    private readonly IMinioService _minioClient;
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAttachmentHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork, IMinioService minioService)
    {
        _mapper = mapper;
        _context = context;
        _unitOfWork = unitOfWork;
        _minioClient = minioService;
    }
    public async Task<ApiResponse> Handle(UpdateAttachmentRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var attachment = await _context.Attachments.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var Message = "";

            var Id = 0;

            if (attachment != null && request.File != null) 
            {
                var isRemovedFile = await _minioClient.RemoveObject(attachment.FileName);

                var createdFileName = await _minioClient.PutObject(request.File);

                attachment.FileName = createdFileName;
                attachment.OriginalFileName = request.OriginalFileName;

                _context.Attachments.Update(attachment);
                await _unitOfWork.Save(cancellationToken);

                Message = "Attachment has updated";
                Id = attachment.Id;


            }
            else if(attachment != null && request.File == null)
            {
                attachment.OriginalFileName = request.OriginalFileName;
                _context.Attachments.Update(attachment);
                await _unitOfWork.Save(cancellationToken);

                Message = "Attachment has updated";
                Id = attachment.Id;

            }
            else
            {
                Message = "Attachment not found";
            }

            return ResponseHandler.GetAppResponse(type, new UpdateAttachmentResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
