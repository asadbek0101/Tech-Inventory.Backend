using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ModelFeature.UpdateModel;

public class UpdateModelHandler : IRequestHandler<UpdateModelRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateModelHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateModelRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Model not found";
        var Id = 0;
        try
        {
            var model = await _context.Models.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (model != null)
            {
                model.Name = request.Name;
                model.Type = request.Type;
                model.Info = request.Info;

                _context.Models.Update(model);
                await _unitOfWork.Save(cancellationToken);

                Message = "Model has updated";
                Id = model.Id;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateModelRepsonse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
