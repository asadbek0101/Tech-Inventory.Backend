using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.DeleteNumberOfOrder;

public class DeleteNumberOfOrderHandler : IRequestHandler<DeleteNumberOfOrderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNumberOfOrderHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async  Task<ApiResponse> Handle(DeleteNumberOfOrderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var numberOfOrder = await _context.NumberOfOrders.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (numberOfOrder == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteNumberOfOrderResponse { Id = 0, Message = "Number Of Order not found" });
            }
            _context.NumberOfOrders.Remove(numberOfOrder);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteNumberOfOrderResponse { Id = request.Id, Message = "Number Of Order has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
