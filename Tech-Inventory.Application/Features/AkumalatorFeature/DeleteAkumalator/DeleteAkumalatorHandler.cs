using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.DeleteAkumalator;

public class DeleteAkumalatorHandler : IRequestHandler<DeleteAkumalatorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAkumalatorHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteAkumalatorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var akumalator = await _context.Akumalators.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (akumalator == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteAkumalatorResponse { Id = 0, Message = "Akumalator not found" });
            }
            _context.Akumalators.Remove(akumalator);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteAkumalatorResponse { Id = request.Id, Message = "Akumalator has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
