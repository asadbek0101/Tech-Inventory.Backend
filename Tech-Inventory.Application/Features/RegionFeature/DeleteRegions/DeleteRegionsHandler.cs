using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.RegionFeature.DeleteRegion;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RegionFeature.DeleteRegions;

public class DeleteRegionsHandler : IRequestHandler<DeleteRegionsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRegionsHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteRegionsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var regions = new List<Region>();

            foreach (var id in request.RegionIds)
            {
                var region = await _context.Regions.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (region != null)
                {
                    regions.Add(region);
                }
            }

            _context.Regions.RemoveRange(regions);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteRegionResponse { Message = "Regions have deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
