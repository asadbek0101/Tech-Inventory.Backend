using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttachmentFeature.CreateAttachment;

public class CreateAttachmentHandler : IRequestHandler<CreateAttachmentRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMinioService _minioClient;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAttachmentHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork, IMinioService minioClient)
    {
        _mapper = mapper;
        _context = context;
        _unitOfWork = unitOfWork;
        _minioClient = minioClient;
    }
    public async Task<ApiResponse> Handle(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var createdFileName = await _minioClient.PutObject(request.File);
            var attachment = new Attachment();
            var message = "";

            if (createdFileName != "" && createdFileName != null)
            {
                attachment = _mapper.Map<Attachment>(request);

                attachment.FileSize = "0";
                attachment.FileName = createdFileName;

                _context.Attachments.Add(attachment);
                await _unitOfWork.Save(cancellationToken);

                message = "Attachment has created";
            }
            else
            {
                message = "Something went wrong";
            }
            

            return ResponseHandler.GetAppResponse(type, new CreateAttachmentResponse { Id = attachment.Id, Message = message  });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
