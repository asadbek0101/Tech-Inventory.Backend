using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.UpdateVideoRecorder;

public class UpdateVideoRecorderHandler : IRequestHandler<UpdateVideoRecorderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVideoRecorderHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateVideoRecorderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Video Recorder not found";
        var Id = 0;
        try
        {
            var videoRecorder = await _context.VideoRecorders.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (videoRecorder != null) 
            {
                videoRecorder.ModelId = request.ModelId;
                videoRecorder.Info = request.Info;

                _context.VideoRecorders.Update(videoRecorder);
                await _unitOfWork.Save(cancellationToken);

                Id = videoRecorder.Id;
                Message = "Video recorder has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateVideoRecorderResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
