using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SocketFeature.DeleteSocket;

public class DeleteSocketHandler : IRequestHandler<DeleteSocketRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSocketHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteSocketRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var socket = await _context.Sockets.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (socket == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteSocketResponse { Id = 0, Message = "Socket not found" });
            }
            _context.Sockets.Remove(socket);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteSocketResponse { Id = request.Id, Message = "Socket has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
