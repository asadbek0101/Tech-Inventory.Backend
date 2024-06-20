using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CounterFeature.UpdateCounter;

public class UpdateCounterHandler : IRequestHandler<UpdateCounterRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCounterHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateCounterRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Counter not found!";
        var Id = 0;
        try
        {
            var counter = await _context.Counters.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (counter != null)
            {
                counter.ModelId = request.ModelId;
                counter.NumberOfConcern = request.NumberOfConcern;
                counter.Info = request.Info;

                _context.Counters.Update(counter);
                await _unitOfWork.Save(cancellationToken);

                Id = counter.Id;
                Message = "Counter has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateCounterResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
