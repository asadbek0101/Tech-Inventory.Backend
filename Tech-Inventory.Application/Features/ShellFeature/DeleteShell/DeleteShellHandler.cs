using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ShellFeature.DeleteShell;

public class DeleteShellHandler : IRequestHandler<DeleteShellRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteShellHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteShellRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var shell = await _context.Shells.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (shell == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteShellResponse { Id = 0, Message = "Shell not found" });
            }
            _context.Shells.Remove(shell);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteShellResponse { Id = request.Id, Message = "Shell has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
