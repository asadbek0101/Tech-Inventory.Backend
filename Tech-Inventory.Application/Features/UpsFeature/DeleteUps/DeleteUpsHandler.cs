using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.UpsFeature.DeleteUps;

public class DeleteUpsHandler : IRequestHandler<DeleteUpsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUpsHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteUpsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var ups = await _context.Ups.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (ups == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteUpsResponse { Id = 0, Message = "ups not found" });
            }
            _context.Ups.Remove(ups);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteUpsResponse { Id = request.Id, Message = "Ups has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
