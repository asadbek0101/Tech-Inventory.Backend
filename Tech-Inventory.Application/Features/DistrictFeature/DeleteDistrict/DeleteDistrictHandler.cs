using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.DistrictFeature.DeleteDistrict;

public class DeleteDistrictHandler : IRequestHandler<DeleteDistrictRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDistrictHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(DeleteDistrictRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var district = await _context.Districts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (district == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteDistrictResponse { Id = 0, Message = "District not found" });
            }
            _context.Districts.Remove(district);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteDistrictResponse { Id = request.Id, Message = "District has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
