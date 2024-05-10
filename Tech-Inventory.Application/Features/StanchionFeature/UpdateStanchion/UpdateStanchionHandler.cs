using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.SocketFeature.UpdateSocket;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StanchionFeature.UpdateStanchion;

public class UpdateStanchionHandler : IRequestHandler<UpdateStanchionRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStanchionHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(UpdateStanchionRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Stanchion not found";
        var Id = 0;
        try
        {
            var stanchion = await _context.Stanchions.Where(x=>x.Id == request.Id).FirstOrDefaultAsync();

            if (stanchion != null)
            {
                stanchion.Count = request.Count;
                stanchion.Info = request.Info;
                stanchion.StanchionTypeId = request.StanchionTypeId;

                _context.Stanchions.Update(stanchion);
                await _unitOfWork.Save(cancellationToken);

                Id = stanchion.Id;
                Message = "Stanchion has updated";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateSocketResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
