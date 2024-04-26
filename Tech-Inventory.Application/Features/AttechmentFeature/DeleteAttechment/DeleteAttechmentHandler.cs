using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AttechmentFeature.DeleteAttechment;

public class DeleteAttechmentHandler : IRequestHandler<DeleteAttechmentRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAttechmentHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteAttechmentRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var attechment = await _context.Attachments.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (attechment == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteAttechmentResponse { Id = 0, Message = "Attachment not found" });
            }
            _context.Attachments.Remove(attechment);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteAttechmentResponse { Id = request.Id, Message = "Attachment has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
