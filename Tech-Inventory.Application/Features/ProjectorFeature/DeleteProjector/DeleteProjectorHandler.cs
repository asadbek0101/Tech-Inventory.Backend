using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ProjectorFeature.DeleteProjector;

public class DeleteProjectorHandler : IRequestHandler<DeleteProjectorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectorHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteProjectorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var projector = await _context.Projectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (projector == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteProjectorResponse { Id = 0, Message = "Projector not found" });
            }
            _context.Projectors.Remove(projector);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteProjectorResponse { Id = request.Id, Message = "Projector has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
