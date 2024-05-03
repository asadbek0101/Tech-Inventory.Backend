using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BoxFeature.DeleteBox;

public class DeleteBoxHandler : IRequestHandler<DeleteBoxRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBoxHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteBoxRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var box = await _context.Boxes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (box == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteBoxResponse { Id = 0, Message = "Box not found" });
            }
            _context.Boxes.Remove(box);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteBoxResponse { Id = request.Id, Message = "Box has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
