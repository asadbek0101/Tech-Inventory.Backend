using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Domain.Entities;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.RegionFeature.DeleteRegion;

namespace Tech_Inventory.Application.Features.DistrictFeature.DeleteDistricts;

public class DeleteDistrictsHandler : IRequestHandler<DeleteDistrictsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDistrictsHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteDistrictsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var districts = new List<District>();

            foreach (var id in request.DistrictIds)
            {
                var district = await _context.Districts.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (district != null)
                {
                    districts.Add(district);
                }
            }

            _context.Districts.RemoveRange(districts);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteRegionResponse { Message = "Districts have deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
