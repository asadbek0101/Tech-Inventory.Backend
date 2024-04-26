using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RackFeature.DeleteRack;

public class DeleteRackHandler : IRequestHandler<DeleteRackRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRackHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteRackRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var rack = await _context.Racks.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (rack == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteRackResponse { Id = 0, Message = "Rack not found" });
            }
            _context.Racks.Remove(rack);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteRackResponse { Id = request.Id, Message = "Rack has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
