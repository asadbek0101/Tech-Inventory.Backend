using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RegionFeature.DeleteRegion;

public class DeleteRegionHandler : IRequestHandler<DeleteRegionRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRegionHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(DeleteRegionRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var region = await _context.Regions.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if(region == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteRegionResponse { Id = 0, Message = "Region not found" });
            }
            _context.Regions.Remove(region);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteRegionResponse { Id = request.Id, Message = "Region has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
