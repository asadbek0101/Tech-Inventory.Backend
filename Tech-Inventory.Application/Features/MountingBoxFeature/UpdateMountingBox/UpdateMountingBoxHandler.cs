using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.UpdateMountingBox;

public class UpdateMountingBoxHandler : IRequestHandler<UpdateMountingBoxRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMountingBoxHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateMountingBoxRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var mountingBox = await _context.MountingBoxs.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var Message = "Mounting box not found";
            var Id = 0;

            if (mountingBox != null)
            {
                mountingBox.ModelId = request.ModelId;
                mountingBox.Count = request.Count;
                mountingBox.Info = request.Info;

                _context.MountingBoxs.Update(mountingBox);
                await _unitOfWork.Save(cancellationToken);
                Message = "Mounting box has updated!";
                Id = mountingBox.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }


            return ResponseHandler.GetAppResponse(type, new UpdateMountingBoxResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
