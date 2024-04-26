using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ShelfFeature.DeleteShelf;

public class DeleteShelfHandler : IRequestHandler<DeleteShelfRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteShelfHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteShelfRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var shelf = await _context.Shelves.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (shelf == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteShelfResponse { Id = 0, Message = "Shelf not found" });
            }
            _context.Shelves.Remove(shelf);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteShelfResponse { Id = request.Id, Message = "Shelf has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
