using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.StabilizerFeature.DeleteStabilizer;

public class DeleteStabilizerHandler : IRequestHandler<DeleteStabilizerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStabilizerHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteStabilizerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var stabilizer = await _context.Stabilizers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (stabilizer == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteStabilizerResponse { Id = 0, Message = "Stabilizer not found" });
            }
            _context.Stabilizers.Remove(stabilizer);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteStabilizerResponse { Id = request.Id, Message = "Stabilizer has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
