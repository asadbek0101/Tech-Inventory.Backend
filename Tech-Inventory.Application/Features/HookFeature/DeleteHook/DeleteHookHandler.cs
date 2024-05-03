using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.HookFeature.DeleteHook;

public class DeleteHookHandler : IRequestHandler<DeleteHookRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHookHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteHookRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var hook = await _context.Hooks.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (hook == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteHookResponse { Id = 0, Message = "Hook not found" });
            }
            _context.Hooks.Remove(hook);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteHookResponse { Id = request.Id, Message = "Hook has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
