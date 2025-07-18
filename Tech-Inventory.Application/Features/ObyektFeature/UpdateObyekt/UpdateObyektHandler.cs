using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObyektFeature.UpdateObyekt;

public class UpdateObyektHandler : IRequestHandler<UpdateObyektRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateObyektHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateObyektRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Obyekt Not Found";
        var Id= 0;
        try
        {
            var obyekt = await _context.Obyekts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (obyekt != null)
            {
                obyekt.RegionId = request.RegionId;
                obyekt.DistrictId = request.DistrictId;
                obyekt.StreetId = request.StreetId;
                obyekt.ProjectId = request.ProjectId;
                obyekt.NumberOfOrderId = request.NumberOfOrderId;
                obyekt.ObjectClassTypeId = request.ObjectClassTypeId;
                obyekt.ObjectClassId = request.ObjectClassId;
                obyekt.NameAndAddress = request.NameAndAddress;
                obyekt.Latitude = request.Latitude;
                obyekt.Longitude = request.Longitude;
                obyekt.Info = request.Info;
                obyekt.ConnectionType = request.ConnectionType;

                _context.Obyekts.Update(obyekt);
                await _unitOfWork.Save(cancellationToken);
                Message = "Object has updated!";
                Id = obyekt.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }
           

            return ResponseHandler.GetAppResponse(type, new UpdateObyektResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
