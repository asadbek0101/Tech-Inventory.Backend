using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RegionFeature.UpdateRegion;

public class UpdateRegionHandler : IRequestHandler<UpdateRegionRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRegionHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateRegionRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Region Not Found";
        var Id = 0;
        try
        {
            var region = await _context.Regions.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if(region != null)
            {
                region.Name = request.Name;
                region.Info = request.Info;
                _context.Regions.Update(region);
                await _unitOfWork.Save(cancellationToken);
                Id = region.Id;
                Message = "Region has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateRegionResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
