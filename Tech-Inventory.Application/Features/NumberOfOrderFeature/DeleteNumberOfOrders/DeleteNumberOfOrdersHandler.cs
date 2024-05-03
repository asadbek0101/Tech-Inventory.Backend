using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.DeleteNumberOfOrders;

public class DeleteNumberOfOrdersHandler : IRequestHandler<DeleteNumberOfOrdersRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNumberOfOrdersHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteNumberOfOrdersRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var numberOfOrders = new List<NumberOfOrder>();

            foreach (var id in request.NumberOfOrderIds)
            {
                var region = await _context.NumberOfOrders.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (region != null)
                {
                    numberOfOrders.Add(region);
                }
            }

            _context.NumberOfOrders.RemoveRange(numberOfOrders);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteNumberOfOrdersResponse { Message = "Number Of Orders have deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
