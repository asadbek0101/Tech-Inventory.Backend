using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NailFeature.DeleteNail;

public class DeleteNailHandler : IRequestHandler<DeleteNailRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNailHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteNailRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var nail = await _context.Nails.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (nail == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteNailResponse { Id = 0, Message = "Nail not found" });
            }
            _context.Nails.Remove(nail);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteNailResponse { Id = request.Id, Message = "Nail has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
