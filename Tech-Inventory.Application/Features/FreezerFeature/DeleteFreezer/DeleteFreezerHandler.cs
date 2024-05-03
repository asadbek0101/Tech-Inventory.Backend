using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.FreezerFeature.DeleteFreezer;

public class DeleteFreezerHandler : IRequestHandler<DeleteFreezerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFreezerHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteFreezerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var freezer = await _context.Freezers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (freezer == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteFreezerResponse { Id = 0, Message = "Freezer not found" });
            }
            _context.Freezers.Remove(freezer);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteFreezerResponse { Id = request.Id, Message = "Freezer has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
