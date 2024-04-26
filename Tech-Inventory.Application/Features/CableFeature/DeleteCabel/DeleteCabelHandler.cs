using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CableFeature.DeleteCabel;

public class DeleteCabelHandler : IRequestHandler<DeleteCabelRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCabelHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteCabelRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var cabel = await _context.Cabels.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (cabel == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteCabelResponse { Id = 0, Message = "Cabel not found" });
            }
            _context.Cabels.Remove(cabel);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteCabelResponse { Id = request.Id, Message = "Cabel has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
