using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BracketFeature.DeleteBracket;

public class DeleteBracketHandler : IRequestHandler<DeleteBracketRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBracketHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteBracketRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var bracket = await _context.Brackets.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (bracket == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteBracketResponse { Id = 0, Message = "Bracket not found" });
            }
            _context.Brackets.Remove(bracket);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteBracketResponse { Id = request.Id, Message = "Bracket has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
