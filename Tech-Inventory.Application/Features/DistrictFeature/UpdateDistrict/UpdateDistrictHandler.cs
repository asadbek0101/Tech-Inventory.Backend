using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DistrictFeature.UpdateDistrict;

public class UpdateDistrictHandler : IRequestHandler<UpdateDistrictRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDistrictHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateDistrictRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "District not found";
        var Id = 0;
        try
        {
            var district = await _context.Districts.OrderBy(x => x.Id).Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if( district != null )
            {
                district.Name = request.Name;
                district.Info = request.Info;

                _context.Districts.Update(district);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }

            

            return ResponseHandler.GetAppResponse(type, new UpdateDistrictResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
