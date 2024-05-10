using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.UpsFeature.UpdateUps;

public class UpdateUpsHandler : IRequestHandler<UpdateUpsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUpsHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(UpdateUpsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Ups not found";
        var Id = 0;
        try
        {
            var ups = await _context.Ups.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (ups != null)
            {
                ups.ModelId = request.ModelId;
                ups.Power = request.Power;
                ups.Info = request.Info;

                _context.Ups.Update(ups);
                await _unitOfWork.Save(cancellationToken);
                Id = ups.Id;
                Message = "Ups has updated";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateUpsResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
