using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RibbonFeature.DeleteRibbon;

public class DeleteRibbonHandler : IRequestHandler<DeleteRibbonRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRibbonHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteRibbonRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var ribbon = await _context.Ribbons.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (ribbon == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteRibbonResponse { Id = 0, Message = "Ribbon not found" });
            }
            _context.Ribbons.Remove(ribbon);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteRibbonResponse { Id = request.Id, Message = "Ribbon has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
