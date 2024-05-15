using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BracketFeature.UpdateBracket;

public class UpdateBracketHandler : IRequestHandler<UpdateBracketRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBracketHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateBracketRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Bracket not found";
        var Id = 0;
        try
        {
            var bracket = await _context.Brackets.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(bracket != null)
            {
                bracket.ModelId = request.ModelId;
                bracket.Count = request.Count;
                bracket.Info = request.Info;

                _context.Brackets.Update(bracket);
                await _unitOfWork.Save(cancellationToken);

                Id = bracket.Id;
                Message = "Bracket has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }
            

            return ResponseHandler.GetAppResponse(type, new UpdateBracketResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
