using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SvetaforFeature.DeleteSvetafor;

public class DeleteSvetaforHandler : IRequestHandler<DeleteSvetaforRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSvetaforHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteSvetaforRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var svetafor = await _context.SvetoforDetectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (svetafor == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteSvetaforResponse { Id = 0, Message = "Svetafor not found" });
            }
            _context.SvetoforDetectors.Remove(svetafor);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteSvetaforResponse { Id = request.Id, Message = "Svetafor has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
