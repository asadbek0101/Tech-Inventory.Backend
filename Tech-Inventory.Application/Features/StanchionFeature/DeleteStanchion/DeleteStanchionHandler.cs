using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.StanchionFeature.DeleteStanchion;

public class DeleteStanchionHandler : IRequestHandler<DeleteStanchionRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStanchionHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteStanchionRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var stanchion = await _context.Stanchions.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (stanchion == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteStanchionResponse { Id = 0, Message = "Stantion not found" });
            }
            _context.Stanchions.Remove(stanchion);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteStanchionResponse { Id = request.Id, Message = "Stantion has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
