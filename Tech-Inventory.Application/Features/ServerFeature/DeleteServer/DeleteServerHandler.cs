using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ServerFeature.DeleteServer;

public class DeleteServerHandler : IRequestHandler<DeleteServerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServerHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteServerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var server = await _context.Servers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (server == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteServerResponse { Id = 0, Message = "Server not found" });
            }
            _context.Servers.Remove(server);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteServerResponse { Id = request.Id, Message = "Server has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
