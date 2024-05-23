using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.DistrictFeature.UpdateDistrict;

namespace Tech_Inventory.Application.Features.FileFeature.UpdateFile;

public class UpdateFileHandler : IRequestHandler<UpdateFileRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFileHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateFileRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "District not found";
        var Id = 0;
        try
        {
            var attachment = await _context.Attachments.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (attachment != null)
            {
                attachment.OriginalFileName = request.OriginalFileName;

                _context.Attachments.Update(attachment);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }



            return ResponseHandler.GetAppResponse(type, new UpdateDistrictResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
