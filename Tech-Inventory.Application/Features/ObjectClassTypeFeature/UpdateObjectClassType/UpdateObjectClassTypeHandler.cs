using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.UpdateObjectClassType;

public class UpdateObjectClassTypeHandler : IRequestHandler<UpdateObjectClassTypeRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateObjectClassTypeHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateObjectClassTypeRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Object class type not found";
        var Id = 0;
        try
        {
            var objectClassType = await _context.ObjectClassTypes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (objectClassType != null)
            {
                objectClassType.Name = request.Name;
                objectClassType.Info = request.Info;

                _context.ObjectClassTypes.Update(objectClassType);
                await _unitOfWork.Save(cancellationToken);
                Id = objectClassType.Id;
                Message = "Object class type has updated";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateObjectClassTypeResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
