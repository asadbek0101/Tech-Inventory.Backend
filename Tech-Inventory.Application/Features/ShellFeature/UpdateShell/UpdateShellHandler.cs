using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ShellFeature.UpdateShell;

public class UpdateShellHandler : IRequestHandler<UpdateShellRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateShellHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateShellRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Shell not found";
        var Id = 0;
        try
        {
            var shell = await _context.Shells.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (shell != null) 
            {
                shell.Meter = request.Meter;
                shell.Info = request.Info;

                _context.Shells.Update(shell);
                await _unitOfWork.Save(cancellationToken);

                Id = shell.Id;
                Message = "Shell has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }
            
            return ResponseHandler.GetAppResponse(type, new UpdateShellResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
