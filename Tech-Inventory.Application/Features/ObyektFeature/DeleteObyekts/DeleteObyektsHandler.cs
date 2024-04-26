using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Domain.Entities;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.RegionFeature.DeleteRegion;

namespace Tech_Inventory.Application.Features.ObyektFeature.DeleteObyekts;

public class DeleteObyektsHandler : IRequestHandler<DeleteObyektsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteObyektsHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteObyektsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var obyekts = new List<Obyekt>();

            foreach (var id in request.ObyektIds)
            {
                var obyekt = await _context.Obyekts.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (obyekt != null)
                {
                    obyekts.Add(obyekt);
                }
            }

            _context.Obyekts.RemoveRange(obyekts);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteRegionResponse { Message = "Obyekts have deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
