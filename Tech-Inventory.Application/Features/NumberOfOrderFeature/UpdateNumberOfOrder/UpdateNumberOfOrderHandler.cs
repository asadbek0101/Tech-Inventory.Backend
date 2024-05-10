using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.UpdateNumberOfOrder;

public class UpdateNumberOfOrderHandler : IRequestHandler<UpdateNumberOfOrderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNumberOfOrderHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateNumberOfOrderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Number of order not found";
        var Id = 0;
        try
        {
            var numberOfOrder = await _context.NumberOfOrders.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(numberOfOrder  != null)
            {
                numberOfOrder.Number = request.Number;
                numberOfOrder.RegionId = request.RegionId;
                numberOfOrder.Info = request.Info;

                _context.NumberOfOrders.Update(numberOfOrder);
                await _unitOfWork.Save(cancellationToken);
                Message = "Number of order has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateNumberOfOrderResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
