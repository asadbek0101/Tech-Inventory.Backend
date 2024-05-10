using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.DeleteObjectClasses;

public class DeleteObjectClassesHandler : IRequestHandler<DeleteObjectClassesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteObjectClassesHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteObjectClassesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var objectClasses = new List<ObjectClass>();

            foreach (var id in request.ObjectClassIds)
            {
                var objectClass = await _context.ObjectClasses.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (objectClass != null)
                {
                    objectClasses.Add(objectClass);
                }
            }

            _context.ObjectClasses.RemoveRange(objectClasses);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteObjectClassesResponse { Message = "Object classes have deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
