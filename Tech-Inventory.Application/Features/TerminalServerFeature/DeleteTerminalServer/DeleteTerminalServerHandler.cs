using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.DeleteTerminalServer;

public class DeleteTerminalServerHandler : IRequestHandler<DeleteTerminalServerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTerminalServerHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteTerminalServerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var terminalServer = await _context.TerminalServers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (terminalServer == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteTerminalServerResponse { Id = 0, Message = "Terminal Server not found" });
            }
            _context.TerminalServers.Remove(terminalServer);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteTerminalServerResponse { Id = request.Id, Message = "Terminal Server has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
