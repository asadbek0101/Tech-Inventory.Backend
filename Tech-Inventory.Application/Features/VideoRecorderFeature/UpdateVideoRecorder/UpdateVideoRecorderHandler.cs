using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.UpdateVideoRecorder;

public class UpdateVideoRecorderHandler : IRequestHandler<UpdateVideoRecorderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVideoRecorderHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateVideoRecorderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var videoRecorder = _mapper.Map<VideoRecorder>(request);
            _context.VideoRecorders.Update(videoRecorder);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateVideoRecorderResponse { Id = videoRecorder.Id, Message = "VideoRecorder has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
