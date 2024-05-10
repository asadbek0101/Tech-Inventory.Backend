using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.DeleteSpeedChecking;

public class DeleteSpeedCheckingHandler : IRequestHandler<DeleteSpeedCheckingRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSpeedCheckingHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteSpeedCheckingRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var speedChecking = await _context.SpeedCheckings.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (speedChecking == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteSpeedCheckingResponse { Id = 0, Message = "Speed checking not found" });
            }
            _context.SpeedCheckings.Remove(speedChecking);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteSpeedCheckingResponse { Id = request.Id, Message = "Speed checking has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
