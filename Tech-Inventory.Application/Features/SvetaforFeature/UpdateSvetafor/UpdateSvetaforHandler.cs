using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.UpdateSvetafor;

public class UpdateSvetaforHandler : IRequestHandler<UpdateSvetaforRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSvetaforHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateSvetaforRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Id = 0;
        var Message = "Svetafor not found";
        try
        {
            var svetafor = await _context.SvetoforDetectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(svetafor != null)
            {
                svetafor.ModelId = request.ModelId;
                svetafor.CountOfPorts = request.CountOfPorts;
                svetafor.Info = request.Info;

                _context.SvetoforDetectors.Update(svetafor);
                await _unitOfWork.Save(cancellationToken);

                Id = svetafor.Id;
                Message = "Svetafor has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateSvetaforResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
