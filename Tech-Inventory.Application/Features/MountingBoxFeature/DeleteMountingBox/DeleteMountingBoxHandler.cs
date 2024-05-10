using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.ProjectorFeature.DeleteProjector;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.DeleteMountingBox;

public class DeleteMountingBoxHandler : IRequestHandler<DeleteMountingBoxRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMountingBoxHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteMountingBoxRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var mountingBox = await _context.MountingBoxs.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (mountingBox == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteProjectorResponse { Id = 0, Message = "Mounting box not found" });
            }
            _context.MountingBoxs.Remove(mountingBox);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteProjectorResponse { Id = request.Id, Message = "Mounting box has deleted" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
