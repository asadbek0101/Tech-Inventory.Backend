using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.CreateVideoRecorder;

public class CreateVideoRecorderHandler : IRequestHandler<CreateVideoRecorderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVideoRecorderHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateVideoRecorderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var videoRecorder = _mapper.Map<VideoRecorder>(request);
            _context.VideoRecorders.Add(videoRecorder);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateVideoRecorderResponse { Id = videoRecorder.Id, Message = "VideoRecorder has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
