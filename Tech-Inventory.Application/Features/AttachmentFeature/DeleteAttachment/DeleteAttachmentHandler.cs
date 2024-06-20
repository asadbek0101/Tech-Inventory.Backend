using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.AttachmentFeature.DeleteAttachment;

public class DeleteAttachmentHandler : IRequestHandler<DeleteAttachmentRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMinioService _minioService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public DeleteAttachmentHandler(ITechInventoryDB context, IMapper mapper, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IMinioService minioService)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _minioService = minioService;
    }
    public async Task<ApiResponse> Handle(DeleteAttachmentRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var attachment = await _context.Attachments
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (attachment == null) 
            {
                type = ResponseType.Failed;
                return ResponseHandler.GetAppResponse(type, new DeleteAttachmentResponse { Id = request.Id, Message = "Attachment not found" });
            }
            else
            {
                _context.Attachments.Remove(attachment);
                await _unitOfWork.Save(cancellationToken);

                var deletedFile = await _minioService.RemoveObject(attachment.FileName);

                return ResponseHandler.GetAppResponse(type, new DeleteAttachmentResponse { Id = attachment.Id, Message = "Attachment has deleted" });
            }

        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
