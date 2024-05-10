using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BoxFeature.UpdateBox;

public class UpdateBoxHandler : IRequestHandler<UpdateBoxRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBoxHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateBoxRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Box not found";
        var Id = 0;
        try
        {
            var box = await _context
                .Boxes
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (box != null)
            {
                box.TypeId = request.TypeId;
                box.Meter = request.Meter;
                box.Info = request.Info;

                _context.Boxes.Update(box);
                await _unitOfWork.Save(cancellationToken);
               
                Id = box.Id;
                Message = "Box has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateBoxResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
