using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CameraFeature.DeleteCamera;

public class DeleteCameraHandler : IRequestHandler<DeleteCameraRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCameraHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteCameraRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var camera = await _context.Cameras.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (camera == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteCameraResponse { Id = 0, Message = "Camera not found" });
            }
            _context.Cameras.Remove(camera);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteCameraResponse { Id = request.Id, Message = "Camera has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
