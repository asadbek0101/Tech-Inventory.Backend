using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.DeleteGlue;

public class DeleteGlueHandler : IRequestHandler<DeleteGlueRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGlueHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteGlueRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var glue = await _context.GlueForNails.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (glue == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteGlueResponse { Id = 0, Message = "Glue not found" });
            }
            _context.GlueForNails.Remove(glue);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteGlueResponse { Id = request.Id, Message = "Glue has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
