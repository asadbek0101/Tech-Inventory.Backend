using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.DeleteObjectClassTypes;

public class DeleteObjectClassTypesHandler : IRequestHandler<DeleteObjectClassTypesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteObjectClassTypesHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteObjectClassTypesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var objectClassTypes = new List<ObjectClassType>();

            foreach (var id in request.ObjectClassTypeIds)
            {
                var objectClassType = await _context.ObjectClassTypes.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (objectClassType != null)
                {
                    objectClassTypes.Add(objectClassType);
                }
            }

            _context.ObjectClassTypes.RemoveRange(objectClassTypes);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteObjectClassTypesResponse { Message = "Object class types have deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
