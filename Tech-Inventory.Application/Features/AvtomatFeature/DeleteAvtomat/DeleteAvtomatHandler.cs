using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AvtomatFeature.DeleteAvtomat;

public class DeleteAvtomatHandler : IRequestHandler<DeleteAvtomatRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAvtomatHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteAvtomatRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var avtomat = await _context.Avtomats.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (avtomat == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteAvtomatResponse { Id = 0, Message = "Avtomat not found" });
            }
            _context.Avtomats.Remove(avtomat);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteAvtomatResponse { Id = request.Id, Message = "Avtomat has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
