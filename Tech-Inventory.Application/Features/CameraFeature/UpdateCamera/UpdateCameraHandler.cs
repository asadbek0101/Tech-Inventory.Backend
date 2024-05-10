using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CameraFeature.UpdateCamera;

public class UpdateCameraHandler : IRequestHandler<UpdateCameraRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCameraHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateCameraRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Camera not found";
        var Id = 0;
        try
        {
            var camera = await _context.Cameras.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (camera != null)
            {
                camera.SerialNumber = request.SerialNumber;
                camera.ModelId = request.ModelId;
                camera.Ip = camera.Ip;
                camera.Status = camera.Status;
                camera.Info = request.Info;

                _context.Cameras.Update(camera);
                await _unitOfWork.Save(cancellationToken);

                Message = "Camera has updated!";
                Id = camera.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateCameraResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
