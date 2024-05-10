using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.UpdateObjectClass;

public class UpdateObjectClassHandler : IRequestHandler<UpdateObjectClassRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateObjectClassHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateObjectClassRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Ojbect class not found";
        var Id = 0;
        try
        {
            var objectClass = await _context.ObjectClasses.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (objectClass != null)
            {
                objectClass.Name = request.Name;
                objectClass.Info = request.Info;
                _context.ObjectClasses.Update(objectClass);
                await _unitOfWork.Save(cancellationToken);
                Id = objectClass.Id;
                Message = "Ojbect class has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateObjectClassResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
