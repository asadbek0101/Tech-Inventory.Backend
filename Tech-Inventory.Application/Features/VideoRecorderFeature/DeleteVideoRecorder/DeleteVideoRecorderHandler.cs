using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.DeleteVideoRecorder;

public class DeleteVideoRecorderHandler : IRequestHandler<DeleteVideoRecorderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVideoRecorderHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteVideoRecorderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var videoRecorder = await _context.VideoRecorders.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (videoRecorder == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteVideoRecorderResponse { Id = 0, Message = "Video Recorder not found" });
            }
            _context.VideoRecorders.Remove(videoRecorder);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteVideoRecorderResponse { Id = request.Id, Message = "Video Recorder has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
