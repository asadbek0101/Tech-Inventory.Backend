using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SocketFeature.UpdateSocket;

public class UpdateSocketHandler : IRequestHandler<UpdateSocketRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSocketHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateSocketRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Socket not found";
        var Id = 0;
        try
        {
            var socket = await _context.Sockets.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (socket != null)
            {
                socket.Count = request.Count;
                socket.Info = request.Info;
                socket.ModelId = request.ModelId;

                _context.Sockets.Update(socket);
                await _unitOfWork.Save(cancellationToken);
                Id = socket.Id;
                Message = "Socket has updated!";
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
