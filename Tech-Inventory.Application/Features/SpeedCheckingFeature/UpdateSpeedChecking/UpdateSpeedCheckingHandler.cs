using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.UpdateSpeedChecking;

public class UpdateSpeedCheckingHandler : IRequestHandler<UpdateSpeedCheckingRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSpeedCheckingHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateSpeedCheckingRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Speed checking not found";
        var Id = 0;
        try
        {
            var speedChecking = await _context.SpeedCheckings.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (speedChecking != null)
            {
                speedChecking.SerialNumber = request.SerialNumber;
                speedChecking.ModelId = request.ModelId;
                speedChecking.Info = request.Info;

                _context.SpeedCheckings.Update(speedChecking);
                await _unitOfWork.Save(cancellationToken);
                Id = speedChecking.Id;
                Message = "Speed checking has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateSpeedCheckingResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
