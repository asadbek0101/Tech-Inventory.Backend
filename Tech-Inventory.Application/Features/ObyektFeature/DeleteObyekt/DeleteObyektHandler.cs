using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObyektFeature.DeleteObyekt;

public class DeleteObyektHandler : IRequestHandler<DeleteObyektRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteObyektHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteObyektRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var obyekt = await _context.Obyekts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (obyekt == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteObyektResponse { Id = 0, Message = "Obyekt not found" });
            }
            _context.Obyekts.Remove(obyekt);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteObyektResponse { Id = request.Id, Message = "Obyekt has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
