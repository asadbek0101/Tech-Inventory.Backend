using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SwitchFeature.DeleteSwitch;

public class DeleteSwitchHandler : IRequestHandler<DeleteSwitchRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSwitchHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteSwitchRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var switchT = await _context.Switches.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (switchT == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteSwitchResponse { Id = 0, Message = "Switch not found" });
            }
            _context.Switches.Remove(switchT);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteSwitchResponse { Id = request.Id, Message = "Switch has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
