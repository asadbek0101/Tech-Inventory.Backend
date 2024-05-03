using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CounterFeature.DeleteCounter;

public class DeleteCounterHandler : IRequestHandler<DeleteCounterRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCounterHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteCounterRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var counter = await _context.Counters.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (counter == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteCounterResponse { Id = 0, Message = "Counter not found" });
            }
            _context.Counters.Remove(counter);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteCounterResponse { Id = request.Id, Message = "Counter has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
